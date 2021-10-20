import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';

@Injectable({
	providedIn: 'root'
})
export class OrganizationService {

	constructor(private apiService: ApiService) { }

	getAllOrganizations() {
		return this.apiService.get('organizations');
	}
}
