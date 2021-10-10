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
        this.formSubject = new BehaviorSubject<Form>(JSON.parse(localStorage.getItem('forms')));
        this.form = this.formSubject.asObservable();
    }

    public get formValue(): Form {
        return this.formSubject.value;
    }

  register(params) {
    const form = { ...this.formValue, ...params };
    localStorage.setItem('forms', JSON.stringify(form));
    this.formSubject.next(form);

  }

    logout() {
        // remove user from local storage and set current user to null
        localStorage.removeItem('user');
        this.formSubject.next(null);
        this.router.navigate(['/account/login']);
    }


  getAll() {
      localStorage.getItem('forms');
      return this.http.get<Form[]>(`${environment.apiUrl}/forms`);

    }

  getById(Policy_holder: string) {
    return this.http.get<Form>(`${environment.apiUrl}/forms/${Policy_holder}`);
    }

  update(Policy_holder, params) {
      return this.http.put(`${environment.apiUrl}/forms/${Policy_holder}`, params)
            .pipe(map(x => {
                // update stored user if the logged in user updated their own record
              if (Policy_holder == this.formValue.Policy_holder) {
                    // update local storage
                    const form = { ...this.formValue, ...params };
                    localStorage.setItem('forms', JSON.stringify(form));

                    // publish updated user to subscribers
                    this.formSubject.next(form);
                }
                return x;
            }));
    }

  delete(Policy_holder: string) {
        return this.http.delete(`${environment.apiUrl}/forms/${Policy_holder}`)
            .pipe(map(x => {
                // auto logout if the logged in user deleted their own record
              if (Policy_holder == this.formValue.Policy_holder) {
                    this.logout();
                }
                return x;
            }));
    }
}
