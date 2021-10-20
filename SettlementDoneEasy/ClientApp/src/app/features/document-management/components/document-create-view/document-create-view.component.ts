import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { DocumentManagementModule } from '../../document-management.module';
import { DocumentModel } from '../../models/DocumentModel';

@Component({
	selector: 'app-document-create-view',
	templateUrl: './document-create-view.component.html',
	styleUrls: ['./document-create-view.component.css']
})
export class DocumentCreateViewComponent implements OnInit {

	@Output() submitted: EventEmitter<DocumentModel>;

	constructor() { }

	ngOnInit(): void {
	}

}
