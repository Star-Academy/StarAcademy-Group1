import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EdgeService {

  private baseAddress = "https://localhost:5001/api/v1";

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }


  public getEdge(edgeId:string): Observable<JSON> {

    var url = `${this.baseAddress}/edges/${edgeId}`;
    
    var httpOptions = {
    };

    return this.http.get<JSON>(url ,httpOptions).pipe(
      tap(_ => this.log(`got edge id=${edgeId}`)),
      catchError(this.handleError<JSON>('getEdge'))
    );
  }

  public deleteEdge(edgeId:string): Observable<JSON>{

    var url = `${this.baseAddress}/edges/${edgeId}`;
    
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.delete<JSON>(url,httpOptions).pipe(
      tap(_ => this.log(`deleted edge id=${edgeId}`)),
      catchError(this.handleError<JSON>('deleteEdge'))
    );
  }

  public addEdge(edge:JSON):Observable<JSON>{
    var url = `${this.baseAddress}/edges`;
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post<JSON>(url, edge, httpOptions)
    .pipe(
      tap(_ => this.log(`added edge`)),
      catchError(this.handleError<JSON>('addEdge', JSON))
    );
  }

  public updateEdge(edge:JSON){
    var url = `${this.baseAddress}/edges`;
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    
    return this.http.put<JSON>(url, edge, httpOptions)
    .pipe(
      tap(_ => this.log('updated edge')),
      catchError(this.handleError<JSON>('updateEdge', JSON))
    );
  }

  public getAllEdges(filter:JSON){
    // todo
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
