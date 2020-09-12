import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  public getAllEdges(filter: JSON) {
    // todo
  }

  public async deleteEdge(edgeId: string): Promise<void> {

    var url = `${this.baseAddress}/edges/${edgeId}`;

    this.http.delete<JSON>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted edge id=${edgeId}`)),
      catchError(this.handleError<JSON>('deleteEdge'))
    ).subscribe(_ => { }); // Todo: test
  }

  public async addEdge(edge: JSON): Promise<void> { // Todo: error handling ?
    var url = `${this.baseAddress}/edges`;

    this.http.post<JSON>(url, edge, this.httpOptions)
      .pipe(
        tap(_ => this.log(`added edge`)),
        catchError(this.handleError<JSON>('addEdge', JSON))
      ).subscribe(_ => { });
  }

  public async updateEdge(edge: JSON): Promise<void> {
    var url = `${this.baseAddress}/edges`;

    this.http.put<JSON>(url, edge, this.httpOptions)
      .pipe(
        tap(_ => this.log('updated edge')),
        catchError(this.handleError<JSON>('updateEdge', JSON))
      ).subscribe(_ => { });
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
