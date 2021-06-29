import { Component, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';

import { DebtInstallmentDataSource } from '../../../../data/debtInstallment/types/debt-installment-data-source';
import { DialogResult } from '../../../../data/dialog/types/dialog-result';
import { DialogComponent } from '../../../../shared/components/dialog/dialog.component';
import { FormDebtInstallmentComponent } from '../form-debt-installment/form-debt-installment.component';

@Component({
  selector: 'app-form-debt-security',
  templateUrl: './form-debt-security.component.html',
  styleUrls: ['./form-debt-security.component.css']
})
export class FormDebtSecurityComponent implements OnInit {

  @ViewChild(MatTable, { static: true }) table: MatTable<DebtInstallmentDataSource>;

  dialogRef: MatDialogRef<DialogComponent, any>;
  dataSource: DebtInstallmentDataSource[] = [];
  debtSecurity: FormGroup;
  displayedColumns: string[] = ['debtInstallmentId', 'dueDate', 'installmentAmount'];

  constructor(
    private dialog: MatDialog,
    private formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.createForm();
  }

  closeDialog() {
    this.dialogRef.close();
  }

  getControl(field: string): AbstractControl {
    return this.debtSecurity.get(field);
  }

  isFieldInvalid(field: string): boolean {
    return (
      (!this.getControl(field).valid && this.getControl(field).touched) ||
      (this.getControl(field).untouched)
    );
  }

  isValidForm(): boolean {
    let isValid = true;

    if (this.debtSecurity.invalid || this.dataSource.length == 0) {
      isValid = false;
    }

    return isValid;
  }

  openDialog(action: string) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '450px',
      data: {
        action,
        component: FormDebtInstallmentComponent,
        title: 'Adicionar parcela'
      }
    });

    this.dialogRef = dialogRef;
    this.observeDialogResult(dialogRef);
  }

  private addRowData(result: DialogResult) {
    if (!result.componentInstance.isValidForm()) {
      return;
    }

    this.setDataSource(result.componentInstance as FormDebtInstallmentComponent);
    this.table.renderRows();
    this.closeDialog();
  }

  private createForm() {
    this.debtSecurity = this.formBuilder.group({
      debtorName: ['', Validators.required],
      debtorCPF: ['', Validators.required],
      interestPercent: ['', Validators.required],
      penaltyPercent: ['', Validators.required]
    });
  }

  private observeDialogResult(dialogRef: MatDialogRef<DialogComponent>) {
    dialogRef.componentInstance.getDialogResult().subscribe(
      (result: DialogResult) => {
        this.addRowData(result);
      }
    )
  }

  private setDataSource(componentInstance: FormDebtInstallmentComponent) {
    this.dataSource.push({
      debtInstallmentId: this.dataSource.length + 1,
      dueDate: componentInstance.debtInstallment.get('dueDate').value,
      installmentAmount: componentInstance.debtInstallment.get('installmentAmount').value
    });
  }
}
