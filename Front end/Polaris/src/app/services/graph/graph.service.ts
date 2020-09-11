import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GraphService {

  private baseAddress = "https://localhost:5001/api/v1";

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  public getGraph(
    nodeFilter: Array<string> = null,
    edgeFilter: Array<string> = null,
    pageIndex: number = null,
    pageSize: number = null
  ): Observable<JSON> {

    var url = `${this.baseAddress}/graph`;

    var httpOptions = {
    };

    return this.http.get<JSON>(url, httpOptions).pipe(
      tap(_ => this.log(`got graph`)),
      catchError(this.handleError<JSON>('getGraph'))
    );
  }

  public getNodeExpansion(
    nodeId: string,
    nodeFilter: Array<string> = null,
    edgeFilter: Array<string> = null,
    nodePageIndex: number = null,
    nodePageSize: number = null,
    nodeOrderBy: string = null,
    edgePageIndex: number = null,
    edgePageSize: number = null,
    edgeOrderBy: string = null
  ): Observable<JSON> {

    var url = `${this.baseAddress}/graph/expansion/${nodeId}`;
    var httpOptions = {
    };

    return this.http.get<JSON>(url, httpOptions).pipe(
      tap(_ => this.log(`got ${nodeId} expansion`)),
      catchError(this.handleError<JSON>('getNodeExpansion'))
    );
  }

  public getSelectedNodesExpansion(
    nodeIds : Array<string>
  ): Observable<JSON> {

    var url = `${this.baseAddress}/graph/expansion`;
    var httpOptions = {
    };

    return this.http.get<JSON>(url, httpOptions).pipe(
      tap(_ => this.log(`got ${nodeIds} expansion`)),
      catchError(this.handleError<JSON>('getNodeExpansion'))
    );
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
