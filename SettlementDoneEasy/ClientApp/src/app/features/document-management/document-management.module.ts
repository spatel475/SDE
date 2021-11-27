import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';
import { DocumentCreateViewComponent } from './components/document-create-view/document-create-view.component';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { DocumentCardComponent } from './components/document-card/document-card.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { BrowserModule } from '@angular/platform-browser';
import { DocumentViewComponent } from './components/document-view/document-view.component';
import { StatemachineService } from './services/statemachine.service';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatExpansionModule } from '@angular/material/expansion';


@NgModule({
	declarations: [
		DocumentGridComponent,
		DocumentCreateViewComponent,
		DocumentCardComponent,
		DocumentViewComponent,
	],
	imports: [
		CommonModule,
		MatInputModule,
		FormsModule,
		PdfViewerModule,
		MatDialogModule,
		MatFormFieldModule,
		MatExpansionModule,
	],
	exports: [
		DocumentGridComponent,
		DocumentCreateViewComponent,
		DocumentCardComponent,
		DocumentViewComponent
	]
})
export class DocumentManagementModule { }
