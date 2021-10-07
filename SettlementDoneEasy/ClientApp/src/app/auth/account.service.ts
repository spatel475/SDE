import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable } from "rxjs";
import { map } from "rxjs/operators";
import { ApiService } from "../services/api/api.service";
import { UserModel } from "../models/UserModel";
import { LoginReponseModel } from "../models/login/LoginResponseModel";
import { loginModel } from "../models/login/LoginModel";

@Injectable({ providedIn: "root" })
export class AccountService {
	private userSubject: BehaviorSubject<UserModel>;
	public user: Observable<UserModel>;

	constructor(private router: Router, private api: ApiService) {
		let login: LoginReponseModel = JSON.parse(localStorage.getItem("token"));
		this.userSubject = new BehaviorSubject<UserModel>(login?.user);
		this.user = this.userSubject.asObservable();
	}

	public get userValue(): UserModel {
		return this.userSubject.value;
	}

	login(login: loginModel) {
		let observer = this.api.post<LoginReponseModel>(`auth/login`, login);
		observer.subscribe(((response: LoginReponseModel) => {
			if (response.isAuthSuccessful) {
				// store user details and jwt token in local storage to keep user logged in between page refreshes
				localStorage.setItem("token", JSON.stringify(response));
			}

			this.userSubject.next(response.user);
		}));
		return observer;
	}

	logout() {
		// remove user from local storage and set current user to null
		localStorage.removeItem("token");
		this.userSubject.next(null);
		this.router.navigate(["/login"]);
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
