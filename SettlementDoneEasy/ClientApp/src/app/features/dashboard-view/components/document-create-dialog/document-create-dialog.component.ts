import { Component, Inject, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
	templateUrl: './document-create-dialog.component.html',
	styleUrls: ['./document-create-dialog.component.css']
})
export class DocumentCreateDialogComponent implements OnInit {



	constructor(
		public dialogRef: MatDialogRef<DocumentCreateDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public data: DocumentCreateDialogData,
	) { }


	ngOnInit(): void {

	}

	onNoClick() {
		this.dialogRef.close();
	}

}

export class DocumentCreateDialogData {
	public DocTitle: string;
	public ClaimNum: number;
	public ClaimantName: string;
	public SettlementAmount: number;
	public InsuredName: string;
	public DateOfAccident: Date;
	public PlaceOfAccident: string;
	public LawFirmTaxID: number;
	public LawyerName: string;

	public Sender: string;
	public Receiver: string;

}