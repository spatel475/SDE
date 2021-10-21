import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';
import { AppdataService } from 'src/app/services/app-data/appdata.service';
import { DocumentModel } from '../document-management/models/DocumentModel';
import { DocumentService } from '../document-management/services/document.service';

@Component({
	templateUrl: './dashboard-view.component.html',
	styleUrls: ['./dashboard-view.component.css']
})
export class DashboardViewComponent implements OnInit {

	public pageState = "Active Documents";
	public visibleDocuments: DocumentModel[];

	constructor(
		public accountService: AccountService,
		public documentService: DocumentService,
		public appData: AppdataService
	) { }

	ngOnInit(): void {
		this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
			console.log(x);
			this.visibleDocuments = x;
		});
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
