import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";
import { RouterModule } from "@angular/router";
import { UIModule } from "src/app/ui-module";

import { AppComponent } from "./app.component";
import { HomeComponent } from "./home/home.component";
import { AppRoutes } from "./routes";
import { LoginComponent } from "./auth/login/login.component";

@NgModule({
  declarations: [AppComponent, HomeComponent, LoginComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    HttpClientModule,
    FormsModule,
    UIModule,
    RouterModule.forRoot(AppRoutes, { relativeLinkResolution: "legacy" }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
