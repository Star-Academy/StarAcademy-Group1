import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NodeService {

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }


  public getNode(nodeId:string): Observable<string> {

    var url = ""
    
    var httpOptions = {
    };

    return this.http.get<string>(url ,httpOptions).pipe(
      tap(_ => this.log(`got node id=${nodeId}`)),
      catchError(this.handleError<string>('getNode'))
    );
  }


  public deleteNode(nodeId:string): Observable<string>{

    var url = ""
    
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.delete<string>(url,httpOptions).pipe(
      tap(_ => this.log(`deleted node id=${nodeId}`)),
      catchError(this.handleError<string>('deleteNode'))
    );
  }

  public addNode(node:JSON):Observable<JSON>{//post
    var url = ""
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    return this.http.post<JSON>(url, node, httpOptions)
    .pipe(
      tap(_ => this.log(`added node`)),
      catchError(this.handleError<JSON>('addNode', JSON))
    );
  }

  public updateNode(node:JSON){

    var url = ""
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    
    return this.http.put<JSON>(url, node, httpOptions)
    .pipe(
      tap(_ => this.log('updated node')),
      catchError(this.handleError<JSON>('updateNode', JSON))
    );

  }


  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    }
  }

  private log(message: string) {
    this.messageService.add(`NodeService: ${message}`);
  }

}
