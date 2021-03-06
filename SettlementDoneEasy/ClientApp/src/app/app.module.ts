import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { FormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home";
import { LoginComponent } from "./auth/login/login.component";
import { AppRoutes } from "./routes";
import { JwtInterceptor } from "./_helpers/jwt.interceptor";
import { ErrorInterceptor } from "./_helpers/error.interceptor";
import { RegisterComponent } from "./auth/register/register.component";
import { UIModule } from "./ui-module";
import { DocumentManagementModule } from "./features/document-management/document-management.module";
import { DashboardViewModule } from "./features/dashboard-view/dashboard-view.module";

import { MessageService } from "./services/message.service";


@NgModule({
	imports: [
		BrowserModule,
		ReactiveFormsModule,
		HttpClientModule,
		BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
		HttpClientModule,
		FormsModule,
		RouterModule.forRoot(AppRoutes),
		UIModule,
		DocumentManagementModule,
		DashboardViewModule
	],
	declarations: [
		AppComponent,
		HomeComponent,
		LoginComponent,
		RegisterComponent,
	],
	providers: [
		{ provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    MessageService,

	],
	bootstrap: [AppComponent],
})
export class AppModule { }
