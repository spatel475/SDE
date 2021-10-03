import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { HttpClient } from "@angular/common/http";
import { BehaviorSubject, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { ApiService } from "../services/api/api.service";
import { UserModel } from "../models/UserModel";

@Injectable({ providedIn: "root" })
export class AccountService {
	private userSubject: BehaviorSubject<UserModel>;
	public user: Observable<UserModel>;

	constructor(private router: Router, private api: ApiService) {
		this.userSubject = new BehaviorSubject<UserModel>(
			JSON.parse(localStorage.getItem("user"))
		);
		this.user = this.userSubject.asObservable();
	}

	public get userValue(): UserModel {
		return this.userSubject.value;
	}

	login(username, password) {
		this.api.get('users').toPromise()
			.then(x => console.log(x))
			.catch(e => console.warn(e))

		return this.api.post<UserModel>(`auth/login`, { username, password }).pipe(
			map((user) => {
				// store user details and jwt token in local storage to keep user logged in between page refreshes
				localStorage.setItem("user", JSON.stringify(user));
				this.userSubject.next(user);
				return user;
			})
		);
	}

	logout() {
		// remove user from local storage and set current user to null
		localStorage.removeItem("user");
		this.userSubject.next(null);
		this.router.navigate(["/account/login"]);
	}

	register(user: UserModel) {
		return this.api.post(`users/register`, user);
	}

	getAll() {
		return this.api.get<UserModel[]>(`users`);
	}

	getById(id: string) {
		return this.api.get<UserModel>(`users/${id}`);
	}

	update(id, params) {
		return this.api.patch(`users/${id}`, params).pipe(
			map((x) => {
				// update stored user if the logged in user updated their own record
				if (id == this.userValue.id) {
					// update local storage
					const user = { ...this.userValue, ...params };
					localStorage.setItem("user", JSON.stringify(user));

					// publish updated user to subscribers
					this.userSubject.next(user);
				}
				return x;
			})
		);
	}

	delete(id: number) {
		return this.api.delete("users", id).pipe(
			map((x) => {
				// auto logout if the logged in user deleted their own record
				if (id == this.userValue.id) {
					this.logout();
				}
				return x;
			})
		);
	}
}
