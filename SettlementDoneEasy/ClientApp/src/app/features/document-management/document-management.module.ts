import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';



@NgModule({
	declarations: [
		DocumentGridComponent
	],
	imports: [
		CommonModule
	],
	exports: [
		DocumentGridComponent
	]
})
export class DocumentManagementModule { }
