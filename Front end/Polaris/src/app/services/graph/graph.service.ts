import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from '../message/message.service';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GraphService {

  private baseAddress = "https://localhost:5001/api/v1";

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }
    
}
