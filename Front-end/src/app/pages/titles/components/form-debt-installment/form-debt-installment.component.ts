import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-form-debt-installment',
  templateUrl: './form-debt-installment.component.html',
  styleUrls: ['./form-debt-installment.component.css']
})
export class FormDebtInstallmentComponent implements OnInit {

  debtInstallment: FormGroup;

  constructor(
    private formBuilder: FormBuilder
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  getControl(field: string): AbstractControl {
    return this.debtInstallment.get(field);
  }

  isFieldInvalid(field: string): boolean {
    return (
      (!this.getControl(field).valid && this.getControl(field).touched) ||
      (this.getControl(field).untouched)
    );
  }

  isValidForm(): boolean {
    let isValid = true;

    if (this.debtInstallment.invalid) {
      isValid = false;
    }

    return isValid;
  }

  private createForm() {
    this.debtInstallment = this.formBuilder.group({
      debtInstallmentId: [null],
      dueDate: [null, Validators.required],
      installmentAmount: ['', Validators.required]
    });
  }
}
