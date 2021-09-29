import { Routes } from "@angular/router";
import { LoginComponent } from "./auth/login/login.component";
import { HomeComponent } from "./home/home.component";

export const AppRoutes: Routes = [
  { path: "login", component: LoginComponent },
  // { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "**", redirectTo: "" },
];
