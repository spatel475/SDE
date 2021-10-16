import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardViewComponent } from './dashboard-view.component';
import { RouterModule, Routes } from '@angular/router';


const appRoutes: Routes = [
	{ path: '', component: DashboardViewComponent }
];

@NgModule({
	declarations: [
		DashboardViewComponent
	],
	imports: [
		RouterModule.forRoot(appRoutes),
	],
	exports: [
		RouterModule
	]
})
export class DashboardViewModule { }
