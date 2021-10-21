import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { DocumentModel } from '../../models/DocumentModel';

@Component({
	selector: 'document-card',
	templateUrl: './document-card.component.html',
	styleUrls: ['./document-card.component.css']
})
export class DocumentCardComponent implements OnInit {

	@Input() Document: DocumentModel
	constructor() { }

	ngOnInit(): void {
		console.log(this.Document);
	}

	formatDate(date: Date) {
		return new DatePipe('en-US').transform(date);
	}

}
