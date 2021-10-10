import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../../environments/environment';
import { Form } from '../../app/_models';

@Injectable({ providedIn: 'root' })
export class FormService {
    private formSubject: BehaviorSubject<Form>;
  public form: Observable<Form>;

    constructor(
        private router: Router,
        private http: HttpClient
    ) {
        this.formSubject = new BehaviorSubject<Form>(JSON.parse(localStorage.getItem('form')));
        this.form = this.formSubject.asObservable();
    }

    public get formValue(): Form {
        return this.formSubject.value;
    }

  register(forms: Form) { // Results in zone.js:3324 POST http://localhost:4200/form/register 404 (Not Found)
    //(`${environment.apiUrl}/users/register`, forms) Creates a strings an saves it as a user, any change results in 'Not Found'
    return this.http.post(`${environment.apiUrl}/forms/register`, forms);
    //register(params) {
    //const form = { ...this.formValue, ...params };
    //localStorage.setItem('forms', JSON.stringify(form));
    //this.formSubject.next(form);

  }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.formSubject.next(null);
        this.router.navigate(['/account/login']);
    }


  getAll() { // zone.js:3324 GET http://localhost:4200/form 404 (Not Found)
      localStorage.getItem('form');
      return this.http.get<Form[]>(`${environment.apiUrl}/form`);

    }

  getById(Policy_holder: string) {
    return this.http.get<Form>(`${environment.apiUrl}/form/${Policy_holder}`);
    }

  update(Policy_holder, params) {
      return this.http.put(`${environment.apiUrl}/form/${Policy_holder}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
              if (Policy_holder == this.formValue.Policy_holder) {
                    // update local storage
                    const form = { ...this.formValue, ...params };
                    localStorage.setItem('form', JSON.stringify(form));

                    // publish updated user to subscribers
                    this.formSubject.next(form);
                }
                return x;
            }));
    }

  delete(Policy_holder: string) {
        return this.http.delete(`${environment.apiUrl}/form/${Policy_holder}`)
            .pipe(map(x => {
                // auto logout if the logged in user deleted their own record
              if (Policy_holder == this.formValue.Policy_holder) {
                    this.logout();
                }
                return x;
            }));
    }
}
