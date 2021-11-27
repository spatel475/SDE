import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
	providedIn: "root",
})
export class ApiService {
	constructor(private http: HttpClient) { }

	private getURL(subPath: string): string {
		return `/api/${subPath}`;
	}

	post<T>(url: string, body: any, options?: any): Observable<any> {
		console.log("REQUEST: POST",
			"\nURL: " + this.getURL(url),
			"\nBODY: " + body,
			"\nOPTION: " + options,
		);
		return this.http.post<T>(this.getURL(url), body, options);
	}

	patch<T>(url: string, body: any): Observable<any> {
		console.log("REQUEST: PATCH",
			"\nURL: " + this.getURL(url),
			"\nBODY: " + body,
		);
		return this.http.patch<T>(this.getURL(url), body);
	}

	delete<T>(url: string, options: any, ...args: any[]): Observable<any> {
		console.log("REQUEST: DELETE",
			"\nURL: " + this.getURL(url),
			"\nOPTION: " + options,
		);
		let reqURL = this.getURL(url);
		args.forEach((arg) => (reqURL += "/" + arg));
		return this.http.delete<T>(reqURL, options);
	}

	get<T>(url: string, ...args: any[]): Observable<T> {
		console.log("REQUEST: GET",
			"\nURL: " + this.getURL(url),
		);
		let reqURL = this.getURL(url);
		args.forEach((arg) => (reqURL += "/" + arg));

		return this.http.get<T>(reqURL);
	}
}
