import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/services/api/api.service';
import { DocumentModel } from '../models/DocumentModel';
import { ReleaseStateInfo } from '../models/ReleaseStateInfo';
import { ReleaseTrigger } from '../models/releaseTrigger';

@Injectable({
	providedIn: 'root'
})
export class StatemachineService {

	constructor(private apiService: ApiService) {

	}

	public ChangeState(doc: DocumentModel, trigger: ReleaseTrigger): Promise<Boolean> {
		return this.apiService.post("Documents/ChangeState?trigger=" + trigger, doc).toPromise();
	}

	public GetStateInfo(doc: DocumentModel): Promise<ReleaseStateInfo> {
		return this.apiService.post("Documents/GetStateInfo", doc).toPromise();
	}

}
