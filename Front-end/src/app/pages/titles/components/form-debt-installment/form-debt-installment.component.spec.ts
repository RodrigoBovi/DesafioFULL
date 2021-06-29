import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormDebtInstallmentComponent } from './form-debt-installment.component';

describe('FormDebtInstallmentComponent', () => {
  let component: FormDebtInstallmentComponent;
  let fixture: ComponentFixture<FormDebtInstallmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormDebtInstallmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormDebtInstallmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
