import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { first } from "rxjs/operators";
import { AccountService } from "src/app/auth/account.service";

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
		private toastr: ToastrService
	) { }

	ngOnInit() {
		this.userLoginForm = this.formBuilder.group({
			email: ["", [Validators.required, Validators.email]],
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
		this.submitted = true;

		// reset alerts on submit
		this.toastr.clear();

		this.accountService
			.login(this.f.email.value, this.f.password.value)
			.pipe(first())
			.subscribe(
				(data) => {
					this.router.navigate([this.returnUrl]);
				},
				(error) => {
					this.toastr.error(error);
					this.loading = false;
				}
			);
		this.loading = true;
	}
}
