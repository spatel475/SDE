﻿import { Component } from "@angular/core";
import { AccountService } from "./auth/account.service";
import { UserModel } from "./models/UserModel";

@Component({
  selector: "app",
  templateUrl: "app.component.html",
})
export class AppComponent {
  user: UserModel;

  constructor(private accountService: AccountService) {
    this.accountService.user.subscribe((x) => (this.user = x));
  }

  logout() {
    this.accountService.logout();
  }
}
