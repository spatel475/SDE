import { Routes } from "@angular/router";
import { LoginComponent } from "./auth/login/login.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from "./_helpers/auth.guard";

export const AppRoutes: Routes = [
	{ path: "login", component: LoginComponent },
	{ path: "register", component: RegisterComponent },
	{
		path: "",
		component: HomeComponent,
		pathMatch: "full",
		canActivate: [AuthGuard],
	},
	{ path: "**", redirectTo: "" },
];
