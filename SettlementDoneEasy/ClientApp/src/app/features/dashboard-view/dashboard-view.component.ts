import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/auth/account.service';
import { AppdataService } from 'src/app/services/app-data/appdata.service';
import { DocumentModel } from '../document-management/models/DocumentModel';
import { DocumentService } from '../document-management/services/document.service';
import { MatDialog } from '@angular/material/dialog';
import { DocumentCreateDialogComponent, DocumentCreateDialogData } from './components/document-create-dialog/document-create-dialog.component';
import { DocumentData } from '../document-management/models/DocumentData';


@Component({
	templateUrl: './dashboard-view.component.html',
	styleUrls: ['./dashboard-view.component.css']
})
export class DashboardViewComponent implements OnInit {

	public pageState = "Active Documents";
	public visibleDocuments: DocumentModel[];

	public selectedDocuments: DocumentModel[] = [];

	constructor(
		public accountService: AccountService,
		public documentService: DocumentService,
		public appData: AppdataService,
		public dialog: MatDialog
	) { }

	ngOnInit(): void {
		this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
			console.log(x);
			console.log(this.appData.getUser().id);
			this.visibleDocuments = x;
		});
	}

	//Ashmal

	createDocument() {

		var data = new DocumentCreateDialogData();
		data.Sender = this.appData.getUser().email;
		data.Receiver = "";
		data.DocTitle = "Draft Document";

		const dialogRef = this.dialog.open(DocumentCreateDialogComponent, { data: data });

		dialogRef.afterClosed().subscribe((result: DocumentCreateDialogData) => {
			console.log(`Dialog result: ${JSON.stringify(result)}`);

			if (!result) return;

			var doc = new DocumentModel();
			doc.title = result.DocTitle;

			var data = new DocumentData();
			data.ClaimNum = result.ClaimNum;
			data.ClaimantName = result.ClaimantName;
			data.DateOfAccident = result.DateOfAccident;
			data.InsuredName = result.InsuredName;
			data.LawFirmTaxID = result.LawFirmTaxID;
			data.LawyerName = result.LawyerName;
			data.PlaceOfAccident = result.PlaceOfAccident;
			data.Receiver = result.Receiver;
			data.Sender = result.Sender;
			data.SettlementAmount = result.SettlementAmount;

			doc.data = data.ToJson();

			this.documentService.Create(doc, this.appData.getUser().id).then(fuck => this.documentService.GetDocuments(this.appData.getUser().id).then(x => {
				console.log(x);
				this.visibleDocuments = x;
			}));
		});





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

	saveDocument() {
		console.log("Saving Document", this.selectedDocuments[0]);
		this.documentService.Update(this.selectedDocuments[0]);
	}

	logout() {
		console.log("Logout Pressed");
		this.accountService.logout();
	}
}
function DocumentCreateDialog(DocumentCreateDialog: any) {
	throw new Error('Function not implemented.');
}

