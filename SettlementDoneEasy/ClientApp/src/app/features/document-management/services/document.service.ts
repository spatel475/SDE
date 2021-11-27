import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/services/api/api.service';
import { DocumentData } from '../models/DocumentData';
import { DocumentModel } from '../models/DocumentModel';
import { ReleaseTrigger } from '../models/releaseTrigger';
import { StatemachineService } from './statemachine.service';

@Injectable({
	providedIn: 'root'
})
export class DocumentService {

	//be sure to use prepInbound/prepOutbound when sending and recieving documents

	constructor(public apiService: ApiService, private statemachine: StatemachineService) {

	}

	//#region Inbound
	public GetDocuments(userId: number): Promise<DocumentModel[]> {
		return this.apiService.get<DocumentModel[]>("Documents/GetDocumentsByUser", userId).toPromise().then((x: DocumentModel[]) => {


			x.forEach(doc => {
				doc = this.prepInbound(doc);
			});
			return x;
		});
	}

	public ChangeState(document, trigger: ReleaseTrigger) {
		this.statemachine.ChangeState(this.prepOutbound(document), trigger);
	}
	//#endregion

	//#region Outbound
	public Create(document: DocumentModel, userId: number): Promise<any> {
		document.userId = userId;
		document.creationDate = new Date();
		document.templateID = 1;
		document.audits = [];
		console.log(document);

		return this.apiService.post("Documents/Create", this.prepOutbound(document)).toPromise()
	}

	public Update(document: DocumentModel) {
		console.log("Sending update data", document);
		return this.apiService.post<DocumentModel>("Documents/Update", this.prepOutbound(document)).toPromise();
	}
	//#endregion

	private prepOutbound(document: DocumentModel): DocumentModel {
		document.data = DocumentData.ToJson(document.data);
		return document;
	}

	private prepInbound(document: DocumentModel): DocumentModel {
		document.data = DocumentData.FromJson(document.data);
		return document;
	}

}
