import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';
import { DocumentCreateViewComponent } from './components/document-create-view/document-create-view.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';


@NgModule({
	declarations: [
		DocumentGridComponent,
		DocumentCreateViewComponent,
	],
	imports: [
		CommonModule,
		MatInputModule,
		FormsModule
	],
	exports: [
		DocumentGridComponent,
		DocumentCreateViewComponent
	]
})
export class DocumentManagementModule { }
