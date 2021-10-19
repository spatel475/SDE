import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardViewComponent } from './dashboard-view.component';
import { RouterModule, Routes } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { DocumentGridComponent } from './components/document-grid/document-grid.component';


const appRoutes: Routes = [
	{ path: '', component: DashboardViewComponent },
];

@NgModule({
	declarations: [
		DashboardViewComponent,
  DocumentGridComponent,
	],
	imports: [
		RouterModule.forRoot(appRoutes),
		MatIconModule
	],
	exports: [
		RouterModule
	]
})
export class DashboardViewModule { }
