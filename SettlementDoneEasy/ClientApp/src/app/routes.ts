import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./auth/login/login.component";
import { RegisterComponent } from "./auth/register/register.component";
import { DocumentCreateViewComponent } from "./features/document-management/components/document-create-view/document-create-view.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from "./_helpers/auth.guard";

export const AppRoutes: Routes = [
	{
		path: "",
		component: HomeComponent,
		pathMatch: "full",
		canActivate: [AuthGuard],
	},
	{ path: "login", component: LoginComponent },
	{ path: "register", component: RegisterComponent },
	{ path: "test", component: DocumentCreateViewComponent },
	{ path: "**", redirectTo: "" },

];
