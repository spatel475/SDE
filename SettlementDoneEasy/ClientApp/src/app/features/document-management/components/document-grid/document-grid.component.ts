import { Component, Input, OnInit } from '@angular/core';
import { DocumentModel } from '../../models/DocumentModel';
import { DocumentService } from '../../services/document.service';

@Component({
	selector: 'document-grid',
	templateUrl: './document-grid.component.html',
	styleUrls: ['./document-grid.component.css']
})
export class DocumentGridComponent implements OnInit {

	@Input() title: string;
	@Input() documentModels: DocumentModel[] = [];

	constructor() {

	}

	ngOnInit(): void {

	}

}
