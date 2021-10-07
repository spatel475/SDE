import { Injectable } from "@angular/core";
import {
	Router,
	CanActivate,
	ActivatedRouteSnapshot,
	RouterStateSnapshot,
} from "@angular/router";
import { AccountService } from "../auth/account.service";
import { LoginReponseModel } from "../models/login/LoginResponseModel";

@Injectable({ providedIn: "root" })
export class AuthGuard implements CanActivate {
	constructor(private router: Router, private accountService: AccountService) { }

	canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
		let token = localStorage.getItem("token");
		if (!token) {
			// not logged in so redirect to login page with the return url
			this.router.navigateByUrl("login");
			return false;
		}

		let model: LoginReponseModel = JSON.parse(token);
		if (this.tokenExpired(model.token)) {
			this.router.navigateByUrl("login");
			return false;
		}

		return true;
	}

	private tokenExpired(token: string) {
		const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
		return (Math.floor((new Date).getTime() / 1000)) >= expiry;
	}
}
