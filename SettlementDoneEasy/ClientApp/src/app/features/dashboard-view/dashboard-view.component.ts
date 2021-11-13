import { HeaderRowOutlet } from '@angular/cdk/table';
import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';
import { AppdataService } from 'src/app/services/app-data/appdata.service';
import { DocumentModel } from '../document-management/models/DocumentModel';
import { DocumentService } from '../document-management/services/document.service';
import { DocumentAuditModel } from '../document-management/models/DocumentAuditModel';

@Component({
	templateUrl: './dashboard-view.component.html',
	styleUrls: ['./dashboard-view.component.css']
})
export class DashboardViewComponent implements OnInit {

	public pageState = "Active Documents";
	public visibleDocuments: DocumentModel[] = [];
	public selectedDocuments: DocumentModel[] = [];

	//sort based off of state number of the documents
	// state number is ' public state: number;' from DocumentAuditModel.ts
	// work on state for drafts and state for actives ( 0 is draft, 1 -7 is active)
	private bufferedDocuments: DocumentModel[] = [];

	constructor(
		public accountService: AccountService,
		public documentService: DocumentService,
		public appData: AppdataService
	) { }

	ngOnInit(): void {
		this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
			// console.log(x);
			// console.log(this.appData.getUser().id);
			this.visibleDocuments = x;
			this.bufferedDocuments = x;
		});
	}

	createDocument() {
		var doc = new DocumentModel();
		doc.title = "Draft Document";
		this.documentService.Create(doc, this.appData.getUser().id).then(fuck => this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
			console.log(x);
			this.visibleDocuments = x;
			//this.bufferedDocuments = x;
		}));
	}


	selectDocument(document: DocumentModel) {
		this.selectedDocuments.push(document);
	}

	clearDocumentSelection() {
		this.selectedDocuments = [];
	}

	changePageState(title: string) {
		this.pageState = title;
	}

	pageStateChange(state: string) {
		const currentlyVisible = [...this.bufferedDocuments];
		this.bufferedDocuments = this.bufferedDocuments?.filter(document => document.audits?.some(audit => this.getStateNums(state).includes(audit?.state)));
		this.visibleDocuments = this.bufferedDocuments;
		this.bufferedDocuments = currentlyVisible;
	}

	private getStateNums(currentState: string): number[] {
		if (currentState == 'active') return [1, 2, 3, 4, 5, 6, 7];
		if (currentState == 'drafts') return [0];
		if (currentState == 'archieved') return [8, 9];
		return [];
	}

	saveDocument() {
		console.log("Saving Document", this.selectedDocuments[0]);
		this.documentService.Update(this.selectedDocuments[0]);
	}

	logout() {
		console.log("Logout Pressed");
		this.accountService.logout();
	}
}
