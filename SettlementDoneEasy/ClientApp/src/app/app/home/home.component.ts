import { Component } from '@angular/core';

import { ApiService } from '../_services/api/api.service';
import { SignalRService } from '../_services/signal-r/signal-r.service';

import { User } from '@app/_models';
import { AccountService } from '@app/_services';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
  user: User;
  SignalRService: SignalRService;
  apiService: ApiService;


  constructor(public accountService: AccountService ) {
      this.user = this.accountService.userValue;
    

  }
  // changing the paramters for the constructor to private apiService: ApiService, private signalRService: SignalRService
  // will make the code ignore home.component.html.

 
    getMessageFromController() {
      this.apiService.get('Users').subscribe({
        next: (x) => console.log(x),
        error: (err) => console.warn(err)
      });
    }
  

  }
