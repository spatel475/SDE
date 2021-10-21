import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { DocumentModel } from '../../models/DocumentModel';
import { CommonModule } from '@angular/common';
import { AppdataService } from 'src/app/services/app-data/appdata.service';
import { AccountService } from 'src/app/auth/account.service';

@Component({
	selector: 'document-card',
	templateUrl: './document-card.component.html',
	styleUrls: ['./document-card.component.css']
})
export class DocumentCardComponent implements OnInit {

	@Input() Document: DocumentModel
	constructor(public appData: AppdataService, public accountService: AccountService) { }

	ngOnInit(): void {
		console.log(this.Document);
	}

	logout() {
		this.accountService.logout();
	}

	formatDate(date: Date) {
		return new DatePipe('en-US').transform(date);
	}

}
