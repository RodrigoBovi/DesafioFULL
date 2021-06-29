import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormDebtSecurityComponent } from './form-debt-security.component';

describe('FormDebtSecurityComponent', () => {
  let component: FormDebtSecurityComponent;
  let fixture: ComponentFixture<FormDebtSecurityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormDebtSecurityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormDebtSecurityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
