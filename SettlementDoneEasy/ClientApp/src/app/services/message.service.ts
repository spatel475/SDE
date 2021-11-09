import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/http';
import { Routes, RouterModule } from '@angular/router';

@Injectable()
export class MessageService {

  constructor(private http: HttpClient) { }

  sendMessage(body) {
    return this.http.post('http://localhost:5001/SDE', body);
  }
}
