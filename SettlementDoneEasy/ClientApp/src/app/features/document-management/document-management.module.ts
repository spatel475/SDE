import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';
import { DocumentCreateViewComponent } from './components/document-create-view/document-create-view.component';
import { MatInputModule } from '@angular/material/input';



@NgModule({
	declarations: [
		DocumentGridComponent,
		DocumentCreateViewComponent
	],
	imports: [
		CommonModule,
		MatInputModule
	],
	exports: [
		DocumentGridComponent
	]
})
export class DocumentManagementModule { }
