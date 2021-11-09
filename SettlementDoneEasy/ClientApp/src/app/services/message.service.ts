import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/http';

@Injectable()
export class MessageService {

  constructor(private_http: HttpClient) { }

  sendMessage(body) {
    return this._http.post(‘http://localhost:4001/SDE', body);
  }
}
