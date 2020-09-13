import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GraphService {

  private baseAddress = "https://localhost:5001/api/v1/graph";
  private httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  public async getGraph(
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    pageIndex: number = null,
    pageSize: number = null
  ): Promise<JSON> {

    let url = `${this.baseAddress}`;
    let params = `?nodeFilter=${JSON.stringify(nodeFilter)}&edgeFilter=${JSON.stringify(edgeFilter)}`
      + `&pageIndex=${pageIndex}&pageSize=${pageSize}`;

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url + params, this.httpOptions).pipe(
        tap(_ => this.log(`got graph`)),
        catchError(this.handleError<JSON>('getGraph'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async getExpansion(
    nodeId: string,
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    nodePageIndex: number = null,
    nodePageSize: number = null,
    nodeOrderBy: string = null,
    edgePageIndex: number = null,
    edgePageSize: number = null,
    edgeOrderBy: string = null
  ): Promise<JSON> {

    var url = `${this.baseAddress}/expansion/${nodeId}`;

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got ${nodeId} expansion`)),
        catchError(this.handleError<JSON>('getNodeExpansion'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async getNodesExpansion(
    nodeIds: Array<string>
  ): Promise<JSON> {

    var url = `${this.baseAddress}/expansion`;

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got ${nodeIds} expansion`)),
        catchError(this.handleError<JSON>('getNodeExpansion'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async getPaths(
    sourceNodeId: string,
    targetNodeId: string,
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    nodeOrderby: string = null,
    edgeOrderby: string = null,
    nodePageIndex: number = null,
    nodePageSize: number = null,
    edgePageIndex: number = null,
    edgePageSize: number = null 
  ): Promise<void> {

  }

  public async getFlow(
    sourceNodeId: string,
    targetNodeId: string,
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    nodePageIndex: number = null,
    nodePageSize: number = null,
    edgePageIndex: number = null,
    edgePageSize: number = null 
  ): Promise<void> {

  }

  public async getStats(): Promise<void> {

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
