import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/services/api/api.service';
import { DocumentModel } from '../models/DocumentModel';

@Injectable({
	providedIn: 'root'
})
export class DocumentService {



	constructor(public apiService: ApiService) {

	}

	public GetDocuments(userId: number): Promise<DocumentModel[]> {
		return this.apiService.get<DocumentModel[]>("Documents/GetDocumentsByUser?", userId).toPromise();
	}

	public Create(document: DocumentModel): Promise<any> {
		console.log(document);
		return this.apiService.post("Documents/Create", document).toPromise()
	}

	public Update(document: DocumentModel) {

	}



}