import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';

@Component({
	templateUrl: './dashboard-view.component.html',
	styleUrls: ['./dashboard-view.component.css']
})
export class DashboardViewComponent implements OnInit {

	constructor(public accountService: AccountService) { }

	ngOnInit(): void {
	}

	//Ashmal

	logout() {
		console.log("Logout Pressed");
		this.accountService.logout();
	}
}
