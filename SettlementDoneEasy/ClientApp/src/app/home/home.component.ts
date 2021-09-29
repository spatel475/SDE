import { Component } from '@angular/core';
import { ApiService } from '../services/api/api.service';
import { SignalRService } from '../services/signal-r/signal-r.service';

@Component({
	selector: 'app-home',
	templateUrl: './home.component.html',
})
export class HomeComponent {
	constructor(private apiService: ApiService, private signalRService: SignalRService) { }

	getMessageFromController() {
		this.apiService.get('Users').subscribe({
			next: (x) => console.log(x),
			error: (err) => console.warn(err)
		});
	}
}
