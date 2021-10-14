import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./auth/login/login.component";
import { RegisterComponent } from "./auth/register/register.component";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from "./_helpers/auth.guard";

export const AppRoutes: Routes = [
	{ path: "login", component: LoginComponent },
	// { path: 'forgot-password', component: ForgotPasswordComponent },
	{ path: "", redirectTo: "/login", pathMatch: "full" },
	{ path: "**", redirectTo: "" },
];
