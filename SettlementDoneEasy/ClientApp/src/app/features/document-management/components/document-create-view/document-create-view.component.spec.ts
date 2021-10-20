import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DocumentCreateViewComponent } from './document-create-view.component';

describe('DocumentCreateViewComponent', () => {
  let component: DocumentCreateViewComponent;
  let fixture: ComponentFixture<DocumentCreateViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DocumentCreateViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DocumentCreateViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
