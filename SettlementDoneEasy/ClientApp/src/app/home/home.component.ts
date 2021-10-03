import { Component } from "@angular/core";
import { AccountService } from "../auth/account.service";
import { UserModel } from "../models/UserModel";
import { ApiService } from "../services/api/api.service";
import { SignalRService } from "../services/signal-r/signal-r.service";

@Component({ templateUrl: "home.component.html" })
export class HomeComponent {
  user: UserModel;

  constructor(
    private signalRService: SignalRService,
    private apiService: ApiService,
    private accountService: AccountService
  ) {
    this.user = this.accountService.userValue;
  }

  getMessageFromController() {
    this.apiService.get("Users").subscribe({
      next: (x) => console.log(x),
      error: (err) => console.warn(err),
    });
  }
}
