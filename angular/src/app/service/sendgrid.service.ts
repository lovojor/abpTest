import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sendgrid, ResponseSendgrid } from '../model/sendgrid';

@Injectable({
  providedIn: 'root'
})
export class SendgridService {

  constructor(private http: HttpClient) { }


  PushSend(data: Sendgrid): Observable<ResponseSendgrid> {
    return this.http.post<ResponseSendgrid>(`https://reqres.in/api/users`,data);
  }
}
