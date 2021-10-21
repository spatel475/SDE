import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardViewComponent } from './dashboard-view.component';
import { RouterModule, Routes } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { DocumentManagementModule } from '../document-management/document-management.module';
import { MatMenuModule } from '@angular/material/menu';

@NgModule({
	declarations: [
		DashboardViewComponent,
	],
	imports: [
		MatIconModule,
		CommonModule,
		DocumentManagementModule,
		MatMenuModule
	],
	exports: [
		RouterModule
	]
})
export class DashboardViewModule { }
