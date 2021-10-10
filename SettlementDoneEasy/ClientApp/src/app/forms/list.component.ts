import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { FormService } from '../../app/_services';

@Component({ templateUrl: 'list.component.html' })
export class ListComponent implements OnInit {
    forms = null;

    constructor(private formService: FormService) {}

    ngOnInit() {
        this.formService.getAll()
            .pipe(first())
            .subscribe(forms => this.forms = forms);
    }

    deleteForm(id: string) {
        const form = this.forms.find(x => x.id === id);
        form.isDeleting = true;
        this.formService.delete(id)
            .pipe(first())
            .subscribe(() => {
                this.forms = this.forms.filter(x => x.id !== id) 
            });
    }
}
