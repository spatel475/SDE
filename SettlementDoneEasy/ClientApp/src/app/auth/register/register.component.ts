import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { first } from "rxjs/operators";
import { OrganizationModel } from "src/app/models/OrganizationModel";
import { UserModel } from "src/app/models/UserModel";
import { OrganizationService } from "src/app/services/organization/organization.service";
import { RegexUtils } from "src/app/utils/RegexUtils";
import { AccountService } from "../account.service";

@Component({
	selector: "app-register",
	templateUrl: "./register.component.html",
	styleUrls: ["./register.component.scss"],
})
export class RegisterComponent implements OnInit {
	form: FormGroup;
	loading = false;
	submitted = false;
	organizations: OrganizationModel[] = [
		{ id: 1, name: '11', type: 'lawyer' },
		{ id: 2, name: '22', type: 'insurance' }
	];

	constructor(
		private formBuilder: FormBuilder,
		private route: ActivatedRoute,
		private router: Router,
		private accountService: AccountService,
		private organizationService: OrganizationService,
		private toastr: ToastrService
	) {
		this.organizationService.getAllOrganizations().subscribe(
			(data: OrganizationModel[]) => this.organizations = data,
			(err) => console.warn(err)
		);
	}

	ngOnInit() {
		this.form = this.formBuilder.group({
			email: ["", [Validators.required]],
			username: ["", [Validators.required]],
			organization: ["", [Validators.required]],
			password: ['', [Validators.required]],
			password2: ['', [Validators.required]],
		}, { validator: passwordMatchValidator });
	}

	// convenience getter for easy access to form fields
	get f() {
		return this.form.controls;
	}

	login() {
		this.router.navigateByUrl('login');
	}

	togglePasswordVisibility(id: string) {
		let x = document.getElementById(id) as HTMLInputElement;
		x.type === "password" ? (x.type = "text") : (x.type = "password");
	}

	isFormValid() {
		return this.form.valid;
	}

	get password() { return this.form.get('password'); }
	get password2() { return this.form.get('password2'); }

	private isPasswordValid() {
		if (!RegexUtils.passwordValidator(this.password.value)) {
			this.toastr.info('Passwords length must be at least 6 and contain Uppercase Letter, Special Character, and Number')
			return false;
		}
		return true
	}

	/* Called on each input in either password field */
	onPasswordInput() {
		if (passwordMatchValidator(this.form))
			this.password2.setErrors([{ 'passwordMismatch': true }]);
		else
			this.password2.setErrors(null);
	}

	isStepOneValid() {
		return this.form.valid;
	}

	register() {
		let userModel = new UserModel();
		userModel.username = this.f.username.value;
		userModel.email = this.f.email.value;
		userModel.password = this.f.password.value;
		userModel.organization = this.organizations.find(o => o.id == this.f.organization.value);

		let isValid = this.isStepOneValid() && this.isPasswordValid();
		if (!isValid)
			return;

		// reset alerts on submit
		this.toastr.clear();
		this.submitted = true;
		this.loading = true;

		this.accountService
			.register(userModel)
			.subscribe(
				(data) => {
					if (data) {
						this.onSuccesfulRegister(data);
					} else {
						this.onUnsuccessfulRegister();
					}
					this.loading = false;
				},
				(error) => {
					this.toastr.error('Something went wrong during registration. Try different username/email');
					this.loading = false;
				}
			);
	}

	private onSuccesfulRegister(response) {
		this.router.navigateByUrl('');
		this.toastr.clear();
		this.submitted = true;
		this.loading = true;
		this.toastr.success('Registration Successful');
	}

	private onUnsuccessfulRegister() {
		this.toastr.error('Registration not successful');
	}

}


export const passwordMatchValidator: ValidatorFn = (formGroup: FormGroup): ValidationErrors | null => {
	let p1 = formGroup.get('password').value;
	let p2 = formGroup.get('password2').value;

	if (formGroup.get('password').value == null) p1 = '';
	if (formGroup.get('password2').value == null) p2 = '';

	if (p1 === p2)
		return null;
	else
		return { passwordMismatch: true };
};

