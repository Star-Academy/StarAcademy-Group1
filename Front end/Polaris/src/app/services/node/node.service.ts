import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NodeService {

  private Url = "";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }


  public getNode(nodeId: string): Observable<string> {
    return this.http.get<string>(this.Url).pipe(
      tap(_ => this.log('fetched heroes')),
      catchError(this.handleError<string>('getNode', ""))
    );
  }


  public deleteNode(nodeId: string): Observable<string>{

    return this.http.delete<string>(this.Url,this.httpOptions).pipe(
      tap(_ => this.log(`deleted hero id=${nodeId}`)),
      catchError(this.handleError<string>('deleteNode'))
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
