import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';

import { FormService, AlertService } from '../../app/_services';

@Component({ templateUrl: 'add-edit.component.html' })
export class AddEditComponent implements OnInit {
    form: FormGroup;
    Policy_holder: string;
    isAddMode: boolean;
    loading = false;
    submitted = false;

    constructor(
        private formBuilder: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private formService: FormService,
        private alertService: AlertService
    ) {}

    ngOnInit() {
        this.Policy_holder = this.route.snapshot.params['Policy_holder'];
        this.isAddMode = !this.Policy_holder;
        
         this.form = this.formBuilder.group({
           Claim_number: ['', Validators.required],
           Policy_number: ['', Validators.required],
           Policy_holder: ['', Validators.required],
           claimiant_name: ['', Validators.required]

        });

        if (!this.isAddMode) {
            this.formService.getById(this.Policy_holder)
                .pipe(first())
                .subscribe(x => {
                  this.f.Claim_number.setValue(x.Claim_number);
                  this.f.Policy_number.setValue(x.Policy_number);
                  this.f.Policy_holder.setValue(x.Policy_holder);
                  this.f.claimiant_name.setValue(x.claimiant_name);
                });
        }
    }

    // convenience getter for easy access to form fields
    get f() { return this.form.controls; }

    onSubmit() {
        this.submitted = true;

        // reset alerts on submit
        this.alertService.clear();

        // stop here if form is invalid
        if (this.form.invalid) {
            return;
        }

        this.loading = true;
        if (this.isAddMode) {
            this.createForm();
        } else {
            this.updateForm();
        }
    }

    private createForm() {
      //this.formService.register(this.form.value);
      //this.alertService.success('Form added successfully', { keepAfterRouteChange: true });
     // this.router.navigate(['.', { relativeTo: this.route }]);
      this.formService.register(this.form.value)
        .pipe(first())
        .subscribe(
          data => {
            this.alertService.success('User added successfully', { keepAfterRouteChange: true });
            this.router.navigate(['.', { relativeTo: this.route }]);
          },
          error => {
            this.alertService.error(error);
            this.loading = false;
          });
    }

    private updateForm() {
        this.formService.update(this.Policy_holder, this.form.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Update successful', { keepAfterRouteChange: true });
                    this.router.navigate(['..', { relativeTo: this.route }]);
                },
                error => {
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}
