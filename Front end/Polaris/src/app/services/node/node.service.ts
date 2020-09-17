import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { __param } from 'tslib';

@Injectable({
  providedIn: 'root',
})
export class NodeService {
  private baseAddress = 'https://localhost:5001/api/v1';

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) {}

  public async getType(): Promise<JSON> {
    var url = `${this.baseAddress}/nodes/typing`;
    return new Promise<JSON>((resolve) => {
      this.http
        .get(url)
        .pipe(
          tap((_) => this.log(`got type`)),
          catchError(this.handleError<JSON>('getType'))
        )
        .subscribe((json: JSON) => {
          resolve(json);
        });
    });
  }

  public async getNode(nodeId: string): Promise<JSON> {
    var url = `${this.baseAddress}/nodes/${nodeId}`;
    return new Promise<JSON>((resolve) => {
      this.http
        .get(url)
        .pipe(
          tap((_) => this.log(`got node id=${nodeId}`)),
          catchError(this.handleError<JSON>('deleteNode'))
        )
        .subscribe((json: JSON) => {
          resolve(json);
        });
    });
  }

  public deleteNode(nodeId: string) {
    var url = `${this.baseAddress}/nodes/${nodeId}`;
    this.http
      .delete(url)
      .pipe(
        tap((_) => this.log(`deleted node id=${nodeId}`)),
        catchError(this.handleError<JSON>('deleteNode'))
      )
      .subscribe();
  }

  public addNode(node: JSON) {
    var url = `${this.baseAddress}/nodes`;
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };
    this.http
      .post<JSON>(url, node, httpOptions)
      .pipe(
        tap((_) => this.log(`added node`)),
        catchError(this.handleError<JSON>('addNode', JSON))
      )
      .subscribe();
  }

  public updateNode(node: JSON) {
    var url = `${this.baseAddress}/nodes`;
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
    };

    this.http
      .put<JSON>(url, node, httpOptions)
      .pipe(
        tap((_) => this.log('updated node')),
        catchError(this.handleError<JSON>('updateNode'))
      )
      .subscribe();
  }

  public async getNodes(filters: string[], pageIndex, pageSize): Promise<JSON> {
    var url = `${this.baseAddress}/nodes`;
    var params = new HttpParams();
    params = params.append('filters', JSON.stringify(filters));
    params = params.append('pageIndex', pageIndex);
    params = params.append('pageSize', pageSize);
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: params,
    };

    return new Promise<JSON>((resolve) => {
      this.http
        .get(url, httpOptions)
        .pipe(
          tap((_) => this.log(`got nodes`)),
          catchError(this.handleError<JSON>('getNodes'))
        )
        .subscribe((json: JSON) => {
          resolve(json);
        });
    });
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }

  private log(message: string) {
    this.messageService.add(`NodeService: ${message}`);
  }
}
