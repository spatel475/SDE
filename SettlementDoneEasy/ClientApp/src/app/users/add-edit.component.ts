import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { first } from "rxjs/operators";
import { AccountService } from "../auth/account.service";
import { ToastrService } from "ngx-toastr";

@Component({ templateUrl: "add-edit.component.html" })
export class AddEditComponent implements OnInit {
  form: FormGroup;
  id: string;
  isAddMode: boolean;
  loading = false;
  submitted = false;

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}

  ngOnInit() {
    this.id = this.route.snapshot.params["id"];
    this.isAddMode = !this.id;

    // password not required in edit mode
    const passwordValidators = [Validators.minLength(6)];
    if (this.isAddMode) {
      passwordValidators.push(Validators.required);
    }

    this.form = this.formBuilder.group({
      Company: ["", Validators.required],
      CompanyID: ["", Validators.required],
      username: ["", Validators.required],
      password: ["", passwordValidators],
    });

    if (!this.isAddMode) {
      this.accountService
        .getById(this.id)
        .pipe(first())
        .subscribe((x) => {
          this.f.Company.setValue(x.Company);
          this.f.CompanyID.setValue(x.CompanyID);
          this.f.username.setValue(x.username);
        });
    }
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.form.controls;
  }

  onSubmit() {
    this.submitted = true;

    // reset alerts on submit
    this.toastr.clear();

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.loading = true;
    if (this.isAddMode) {
      this.createUser();
    } else {
      this.updateUser();
    }
  }

  private createUser() {
    this.accountService
      .register(this.form.value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.toastr.success("User added successfully");
          this.router.navigate([".", { relativeTo: this.route }]);
        },
        (error) => {
          this.toastr.error(error);
          this.loading = false;
        }
      );
  }

  private updateUser() {
    this.accountService
      .update(this.id, this.form.value)
      .pipe(first())
      .subscribe(
        (data) => {
          this.toastr.success("Update successful");
          this.router.navigate(["..", { relativeTo: this.route }]);
        },
        (error) => {
          this.toastr.error(error);
          this.loading = false;
        }
      );
  }
}
