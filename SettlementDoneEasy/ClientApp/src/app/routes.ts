import { Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { LoginComponent } from "./auth/login/login.component";
import { RegisterComponent } from "./auth/register/register.component";
import { DashboardViewComponent } from "./features/dashboard-view/dashboard-view.component";
import { DashboardViewModule } from "./features/dashboard-view/dashboard-view.module";
import { HomeComponent } from "./home/home.component";
import { AuthGuard } from "./_helpers/auth.guard";

export const AppRoutes: Routes = [
	{ path: "", redirectTo: "dashboard", pathMatch: "full" },
	{ path: "**", redirectTo: "" },
	{ path: "login", component: LoginComponent },
	// { path: 'forgot-password', component: ForgotPasswordComponent },
	{ path: "dashboard", component: DashboardViewComponent },

];
