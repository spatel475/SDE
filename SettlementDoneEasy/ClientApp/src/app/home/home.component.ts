import { Component, OnInit } from "@angular/core";
import { AccountService } from "../auth/account.service";
import { DocumentService } from "../features/document-management/services/document.service";
import { UserModel } from "../models/UserModel";
import { ApiService } from "../services/api/api.service";
import { SignalRService } from "../services/signal-r/signal-r.service";

@Component({ templateUrl: "home.component.html" })
export class HomeComponent implements OnInit {
	user: UserModel;

	constructor(
		private signalRService: SignalRService,
		private apiService: ApiService,
		private accountService: AccountService,
		private documentService: DocumentService
	) {
		this.accountService.user.subscribe((x) => (this.user = x));
	}
	ngOnInit(): void {
		this.documentService.GetDocuments(this.user.id).then(x => {
			console.log(x);
		});
	}



	getMessageFromController() {
		this.apiService.get("Users").subscribe({
			next: (x) => console.log(x),
			error: (err) => console.warn(err),
		});
	}

	logout() {
		this.accountService.logout();
	}
}
