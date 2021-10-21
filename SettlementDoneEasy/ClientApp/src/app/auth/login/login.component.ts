import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { AccountService } from "src/app/auth/account.service";
import { LoginModel } from "src/app/models/login/LoginModel";
import { LoginReponseModel } from "src/app/models/login/LoginResponseModel";
import { ApiService } from "src/app/services/api/api.service";

@Component({
	selector: "app-login",
	templateUrl: "./login.component.html",
	styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
	userLoginForm: FormGroup;
	loading = false;
	submitted = false;
	returnUrl: string;

	constructor(
		private formBuilder: FormBuilder,
		private router: Router,
		private accountService: AccountService,
		private toastr: ToastrService,
	) {
		this.accountService.user.subscribe((x) => this.router.navigateByUrl(''));
	}

	ngOnInit() {
		this.userLoginForm = this.formBuilder.group({
			email: ["", [Validators.email]],
			password: ["", [Validators.required]],
		});
	}

	// convenience getter for easy access to form fields
	get f() {
		return this.userLoginForm.controls;
	}

	togglePasswordVisibility(id: string) {
		let x = document.getElementById(id) as HTMLInputElement;
		x.type === "password" ? (x.type = "text") : (x.type = "password");
	}

	isFormValid() {
		return this.userLoginForm.valid;
	}

	register() {
		this.router.navigateByUrl('register');
	}

	login() {
		// reset alerts on submit
		this.toastr.clear();
		this.submitted = true;
		this.loading = true;

		let loginModel: LoginModel = {
			email: this.f.email.value,
			password: this.f.password.value
		}
		this.accountService
			.login(loginModel)
			.subscribe(
				(data: LoginReponseModel) => {
					if (data.isAuthSuccessful) {
						this.onSuccesfulLogin(data);
					} else {
						this.onUnsuccessfulLogin();
					}
					this.loading = false;
				},
				(error) => {
					this.toastr.error('Unknown error during login');
					console.warn(error);
					this.loading = false;
				}
			);
	}

	private onSuccesfulLogin(response: LoginReponseModel) {
		this.router.navigateByUrl('');
	}

	private onUnsuccessfulLogin() {
		this.toastr.error('Invalid Login');
	}

}
