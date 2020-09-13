import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EdgeService {

  private baseAddress = "https://localhost:5001/api/v1";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService
  ) { }


  public async getEdge(edgeId: string): Promise<JSON> {

    var url = `${this.baseAddress}/edges/${edgeId}`;

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got edge id=${edgeId}`)),
        catchError(this.handleError<JSON>('getEdge'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public getAllEdges(
    filter: string[] = [],
    pageIndex = 0,
    pageSize = 1
  ): Promise<JSON> {
    var url = `${this.baseAddress}/edges?pageIndex=${pageIndex}&pageIndex=${pageSize}`;
    
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      params: new HttpParams().append('filter', JSON.stringify(filter))
    };

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, httpOptions).pipe(
        tap(_ => this.log(`got edges`)),
        catchError(this.handleError<JSON>('getEdge'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async deleteEdge(edgeId: string): Promise<void> {

    var url = `${this.baseAddress}/edges/${edgeId}`;

    this.http.delete<string>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted edge id=${edgeId}`)),
      catchError(this.handleError<string>('deleteEdge'))
    ).subscribe(_ => { });
  }

  public async addEdge(edge: JSON): Promise<void> {
    var url = `${this.baseAddress}/edges`;

    this.http.post<JSON>(url, edge, this.httpOptions)
      .pipe(
        tap(_ => this.log(`added edge`)),
        catchError(this.handleError<JSON>('addEdge'))
      ).subscribe(_ => { });
  }

  public async updateEdge(edge: string): Promise<void> {
    var url = `${this.baseAddress}/edges`;

    this.http.put<string>(url, edge, this.httpOptions)
      .pipe(
        tap(_ => this.log('updated edge')),
        catchError(this.handleError<string>('updateEdge'))
      ).subscribe();
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    }
  }

  private log(message: string) {
    this.messageService.add(`EdgeService: ${message}`);
  }
}
