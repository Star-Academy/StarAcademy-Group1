import { element } from 'protractor';
import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
//TODO: nodeFilter -> node.filter
//TODO:
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
    pageIndex: number = -1,
    pageSize: number = -1
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
    nodePageIndex: number = -1,
    nodePageSize: number = -1,
    nodeOrderBy: string = 'desc',
    edgePageIndex: number = -1,
    edgePageSize: number = -1,
    edgeOrderBy: string = 'desc'
  ): Promise<JSON> {

    let url = `${this.baseAddress}/expansion/${nodeId}?`;
    for (let element of nodeFilter) {
      url += `node=${element}&`;
    }
    for (let element of edgeFilter) {
      url += `edge=${element}&`;
    }
    url = url.substr(0, url.length - 1);

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
    nodeIds: string[],
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    nodePageIndex: number = -1,
    nodePageSize: number = -1,
    nodeOrderBy: string = 'desc',
    edgePageIndex: number = -1,
    edgePageSize: number = -1,
    edgeOrderBy: string = 'desc'
  ): Promise<JSON> {
    console.log(nodeIds + " " + nodeFilter + " " + edgeFilter);
    let url = `${this.baseAddress}/expansion?`;
    for (let element of nodeIds) {
      url += `nodesIds=${element}&`;
    }
    for (let element of nodeFilter) {
      url += `node=${element}&`;
    }
    for (let element of edgeFilter) {
      url += `edge=${element}&`;
    }
    url = url.substr(0, url.length - 1);
    console.log(url);
    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got ${nodeIds} expansion`)),
        catchError(this.handleError<JSON>('getNodesExpansion'))
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
    maxLength: string = '7',
    nodeOrderby: string = 'desc',
    edgeOrderby: string = 'desc',
    nodePageIndex: number = -1,
    nodePageSize: number = -1,
    edgePageIndex: number = -1,
    edgePageSize: number = -1
  ): Promise<JSON> {

    let url = `${this.baseAddress}/paths`;
    url += `?sourceNodeId=${sourceNodeId}&targetNodeId=${targetNodeId}&`;
    for (let element of nodeFilter) {
      url += `node=${element}&`;
    }
    for (let element of edgeFilter) {
      url += `edge=${element}&`;
    }
    url += `maxLenght=${maxLength}&`;
    url = url.substr(0, url.length - 1);
    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got paths`)),
        catchError(this.handleError<JSON>('getPaths'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async getFlow(
    sourceNodeId: string,
    targetNodeId: string,
    nodeFilter: string[] = [],
    edgeFilter: string[] = [],
    nodePageIndex: number = -1,
    nodePageSize: number = -1,
    edgePageIndex: number = -1,
    edgePageSize: number = -1
  ): Promise<JSON> {

    let url = `${this.baseAddress}/max-flow`;
    url += `?sourceNodeId=${sourceNodeId}&targetNodeId=${targetNodeId}&`;

    for (let element of nodeFilter) {
      url += `node=${element}&`;
    }
    for (let element of edgeFilter) {
      url += `edge=${element}&`;
    }
    url = url.substr(0, url.length - 1);

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got flow`)),
        catchError(this.handleError<JSON>('getFlow'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
  }

  public async getStats(): Promise<JSON> {

    let url = `${this.baseAddress}/stats`;

    return new Promise<JSON>((resolve) => {
      this.http.get<JSON>(url, this.httpOptions).pipe(
        tap(_ => this.log(`got stats`)),
        catchError(this.handleError<JSON>('getStats'))
      ).subscribe((result: JSON) => {
        resolve(result)
      })
    });
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
