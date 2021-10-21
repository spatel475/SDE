import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { DocumentManagementModule } from '../../document-management.module';
import { DocumentModel } from '../../models/DocumentModel';
import { DocumentService } from '../../services/document.service';


@Component({
	selector: 'document-create-view',
	templateUrl: './document-create-view.component.html',
	styleUrls: ['./document-create-view.component.css']
})
export class DocumentCreateViewComponent implements OnInit {

	@Output() submitted = new EventEmitter<DocumentModel>();
	@Input() UserId: number;


	public documentState = new DocumentModel();

	constructor(public documentService: DocumentService) { }

	ngOnInit(): void {
	}

	onSubmit() {

		this.documentService.Create(this.documentState, this.UserId);
		this.submitted.emit(this.documentState);
	}

}
