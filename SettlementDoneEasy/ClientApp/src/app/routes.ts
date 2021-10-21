import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./auth/login/login.component";
import { RegisterComponent } from "./auth/register/register.component";
import { DashboardViewComponent } from "./features/dashboard-view/dashboard-view.component";
import { DocumentCreateViewComponent } from "./features/document-management/components/document-create-view/document-create-view.component";
import { HomeComponent } from "./home/home.component";
import { LoginModel } from "./models/login/LoginModel";
import { AuthGuard } from "./_helpers/auth.guard";

export const AppRoutes: Routes = [
	{ path: "login", component: LoginComponent },
	{
		path: "",
		component: DashboardViewComponent,
		pathMatch: "full",
		canActivate: [AuthGuard],
	},
	{ path: "**", redirectTo: "" },

];
