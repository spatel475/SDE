import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardViewComponent } from './dashboard-view.component';
import { RouterModule, Routes } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { DocumentManagementModule } from '../document-management/document-management.module';


const appRoutes: Routes = [
	{ path: '', component: DashboardViewComponent },
];

@NgModule({
	declarations: [
		DashboardViewComponent,
	],
	imports: [
		RouterModule.forRoot(appRoutes),
		MatIconModule,
		DocumentManagementModule,
	],
	exports: [
		RouterModule
	]
})
export class DashboardViewModule { }
