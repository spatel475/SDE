import { Component, Input, OnInit } from '@angular/core';

@Component({
	selector: 'document-grid',
	templateUrl: './document-grid.component.html',
	styleUrls: ['./document-grid.component.css']
})
export class DocumentGridComponent implements OnInit {

	@Input() title: string;



	constructor() { }

	ngOnInit(): void {
	}

}
