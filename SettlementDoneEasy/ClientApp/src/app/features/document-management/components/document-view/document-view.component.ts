import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { DocumentModel } from '../../models/DocumentModel';

@Component({
	selector: 'document-view',
	templateUrl: './document-view.component.html',
	styleUrls: ['./document-view.component.css']
})
export class DocumentViewComponent implements OnInit {

	@Input() document: DocumentModel;
	@Input() state: string = 'view';

	constructor() { }

	ngOnInit(): void {
		console.log(document);
	}

	formatDate(date: Date) {
		return new DatePipe('en-US').transform(date);
	}
}
