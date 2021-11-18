import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/services/api/api.service';
import { DocumentModel } from '../models/DocumentModel';
import { ReleaseTrigger } from '../models/releaseTrigger';

@Injectable({
	providedIn: 'root'
})
export class StatemachineService {

	constructor(private apiService: ApiService) {

	}

	public ChangeState(doc: DocumentModel, trigger: ReleaseTrigger) {
		this.apiService.post("Documents/ChangeState", trigger);
	}

}
