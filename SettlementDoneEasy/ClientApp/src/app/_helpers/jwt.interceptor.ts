import { Injectable } from "@angular/core";
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
} from "@angular/common/http";
import { Observable } from "rxjs";
import { AccountService } from "../auth/account.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private accountService: AccountService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    let clonedReq: HttpRequest<any>;

    if (localStorage.getItem("token") != null) {
      clonedReq = request.clone({
        headers: request.headers.set(
          "Authorization",
          "Bearer " + localStorage.getItem("token")
        ),
      });
    } else {
      clonedReq = request.clone();
    }

    return next.handle(request);
  }
}
