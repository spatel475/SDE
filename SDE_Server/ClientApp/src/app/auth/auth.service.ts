import { Injectable } from "@angular/core";
import { ApiService } from "../services/api/api.service";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private api: ApiService) {}

  login(username: string, password: string) {
    throw Error("Not implemented");
  }
}
