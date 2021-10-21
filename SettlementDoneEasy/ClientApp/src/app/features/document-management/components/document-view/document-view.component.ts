import { Component, Input, OnInit } from '@angular/core';
import { DocumentModel } from '../../models/DocumentModel';

@Component({
	selector: 'document-view',
	templateUrl: './document-view.component.html',
	styleUrls: ['./document-view.component.css']
})
export class DocumentViewComponent implements OnInit {

	@Input() document: DocumentModel;

	constructor() { }

	ngOnInit(): void {
	}

}
