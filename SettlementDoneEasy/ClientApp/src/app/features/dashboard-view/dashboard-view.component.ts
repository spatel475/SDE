import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';

@Component({
	templateUrl: './dashboard-view.component.html',
	styleUrls: ['./dashboard-view.component.css']
})
export class DashboardViewComponent implements OnInit {

	public pageState = "Active Documents";

	constructor(public accountService: AccountService) { }

	ngOnInit(): void {
	}

	//Ashmal

	changePageState(title: string) {
		this.pageState = title;
	}

	logout() {
		console.log("Logout Pressed");
		this.accountService.logout();
	}
}
