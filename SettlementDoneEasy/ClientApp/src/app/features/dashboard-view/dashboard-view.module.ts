import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardViewComponent } from './dashboard-view.component';
import { RouterModule, Routes } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { DocumentManagementModule } from '../document-management/document-management.module';
import { MatMenuModule } from '@angular/material/menu';
import { DocumentCreateDialogComponent } from './components/document-create-dialog/document-create-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatDatepickerModule } from '@angular/material/datepicker';

@NgModule({
	declarations: [
		DashboardViewComponent,
		DocumentCreateDialogComponent,
	],
	imports: [
		MatIconModule,
		CommonModule,
		FormsModule,
		DocumentManagementModule,
		MatMenuModule,
		MatDialogModule,
		MatInputModule,
		MatFormFieldModule,
		MatButtonModule,
		MatDividerModule,
		MatExpansionModule,
		MatDatepickerModule
	],
	exports: [
		RouterModule
	]
})
export class DashboardViewModule { }
