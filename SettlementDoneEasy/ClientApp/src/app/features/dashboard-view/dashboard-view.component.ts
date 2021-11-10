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
	public visibleDocuments: DocumentModel[];
	public bufferedDocuments: DocumentModel[];
	//sort based off of state number of the documents
	// state number is ' public state: number;' from DocumentAuditModel.ts
	// work on state for drafts and state for actives ( 0 is draft, 1 -7 is active)
	public selectedDocuments: DocumentModel[] = [];

	constructor(
		public accountService: AccountService,
		public documentService: DocumentService,
		public appData: AppdataService
	) { }

	ngOnInit(): void {
		this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
			console.log(x);
			console.log(this.appData.getUser().id);
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
			this.bufferedDocuments = x;
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
	pageStateActive() { // states 1 - 7
		var i: number;
		var j: number;

		for (i = 0; i < (this.bufferedDocuments.length - 1); i++) { // DocumentModel Array
			for (j = 1; j <= 7; j++) {// DocumentAuditModel Array
				if (this.bufferedDocuments[i].audits[j].state > 0 && this.bufferedDocuments[i].audits[j].state < 8) {
					this.visibleDocuments = this.bufferedDocuments;
					console.log();

				}
			}

		}

	}

	pageStateArchived() { // state 8 and 9
		var i: number;
		var j: number;

		for (i = 0; i < (this.bufferedDocuments.length - 1); i++) { // DocumentModel Array
			for (j = 8; j <= 9; j++) {// DocumentAuditModel Array
				if (this.bufferedDocuments[i].audits[j].state > 0 && this.bufferedDocuments[i].audits[j].state < 8) {
					this.visibleDocuments = this.bufferedDocuments;
					console.log();

				}
			}

		}

	}

	pageStateDraft() { // state 0
		var i: number;
		var j: number;

		for (i = 0; i < (this.bufferedDocuments.length - 1); i++) { // DocumentModel Array
			for (j = 0; j <= 0; j++) {// DocumentAuditModel Array
				if (this.bufferedDocuments[i].audits[j].state == 0) {
					this.visibleDocuments = this.bufferedDocuments;
					console.log();

				}
			}

		}

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
