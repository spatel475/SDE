import { Injectable } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';
import { UserModel } from 'src/app/models/UserModel';

@Injectable({
	providedIn: 'root'
})
export class AppdataService {

	private user: UserModel;
	public setUser(user: UserModel) { this.user = user; }
	public getUser() { return this.user; }

	constructor(private accountService: AccountService) {
		this.accountService.user.subscribe((x) => (this.user = x));
	}
}
