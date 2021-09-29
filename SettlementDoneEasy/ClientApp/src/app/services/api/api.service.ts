import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  private url = "https://localhost:5001";
  constructor(private http: HttpClient) {}

  private getURL(subPath: string): string {
    return `${this.url}/${subPath}`;
  }

  post<T>(url: string, body: any, options?: any): Observable<any> {
    return this.http.post<T>(this.getURL(url), body, options);
  }

  patch<T>(url: string, body: any): Observable<any> {
    return this.http.patch<T>(this.getURL(url), body);
  }

  delete<T>(url: string, options: any, ...args: any[]): Observable<any> {
    let reqURL = this.getURL(url);
    args.forEach((arg) => (reqURL += "/" + arg));
    return this.http.delete<T>(reqURL, options);
  }

  get<T>(url: string, ...args: any[]): Observable<T> {
    let reqURL = this.getURL(url);
    args.forEach((arg) => (reqURL += "/" + arg));
    return this.http.get<T>(reqURL);
  }
}
