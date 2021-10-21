import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';
import { DocumentCreateViewComponent } from './components/document-create-view/document-create-view.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { DocumentCardComponent } from './components/document-card/document-card.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { BrowserModule } from '@angular/platform-browser';


@NgModule({
	declarations: [
		DocumentGridComponent,
		DocumentCreateViewComponent,
		DocumentCardComponent,
	],
	imports: [
		CommonModule,
		MatInputModule,
		FormsModule,
		PdfViewerModule,
	],
	exports: [
		DocumentGridComponent,
		DocumentCreateViewComponent,
		DocumentCardComponent
	]
})
export class DocumentManagementModule { }
