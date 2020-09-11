import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class NodeService {

  private baseAddress = "https://localhost:5001/api/v1";

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  public getNode(nodeId:string): Observable<JSON> {

    var url = `${this.baseAddress}/nodes/${nodeId}`;
    
    var httpOptions = {
    };

    return this.http.get<JSON>(url ,httpOptions).pipe(
      tap(_ => this.log(`got node id=${nodeId}`)),
      catchError(this.handleError<JSON>('getNode'))
    );
  }

  public deleteNode(nodeId:string): Observable<JSON>{

    var url = `${this.baseAddress}/nodes/${nodeId}`;
    
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    return this.http.delete<JSON>(url,httpOptions).pipe(
      tap(_ => this.log(`deleted node id=${nodeId}`)),
      catchError(this.handleError<JSON>('deleteNode'))
    );
  }

  public addNode(node:JSON):Observable<JSON>{
    var url = `${this.baseAddress}/nodes`;
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
    var url = `${this.baseAddress}/nodes`;
    var httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };
    
    return this.http.put<JSON>(url, node, httpOptions)
    .pipe(
      tap(_ => this.log('updated node')),
      catchError(this.handleError<JSON>('updateNode', JSON))
    );
  }

  public getAddNodes(filter:JSON){
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
    this.messageService.add(`NodeService: ${message}`);
  }
}
