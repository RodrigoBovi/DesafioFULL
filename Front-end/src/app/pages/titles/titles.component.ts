import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

import { DebtSecurityService } from '../../data/debtSecurity/services/debt-security.service';
import { DebtSecurity } from '../../data/debtSecurity/types/debt-security';
import { DebtSecurityDataSource } from '../../data/debtSecurity/types/debt-security-data-source';
import { DialogResult } from '../../data/dialog/types/dialog-result';
import { DialogComponent } from '../../shared/components/dialog/dialog.component';
import { FormDebtSecurityComponent } from './components/form-debt-security/form-debt-security.component';

@Component({
  selector: 'app-titles',
  templateUrl: './titles.component.html',
  styleUrls: ['./titles.component.css']
})
export class TitlesComponent implements OnInit {

  dataSource: DebtSecurityDataSource[] = [];
  dialogRef: MatDialogRef<DialogComponent, any>;
  displayedColumns: string[] = ['debtSecurityId', 'debtorName', 'numberInstallments', 'originalValue', 'daysOverdue', 'updatedAmount'];

  constructor(
    private dialog: MatDialog,
    private debtSecurityService: DebtSecurityService
  ) { }

  ngOnInit(): void {
  }

  openDialog(action: string) {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '450px',
      data: {
        action,
        component: FormDebtSecurityComponent,
        title: 'Adicionar título'
      }
    });

    this.dialogRef = dialogRef;
    this.observeDialogResult(dialogRef);
  }

  private addRowData(result: DialogResult) {
    if (!result.componentInstance.isValidForm()) {
      return;
    }

    this.fetchData(result.componentInstance);
  }

  private createDebtSecurity(body: DebtSecurity) {
    this.debtSecurityService.createDebtSecurity(body).subscribe(
      data => {

      },
      error => {

      }
    )
  }

  private fetchData(componentInstance: FormDebtSecurityComponent): DebtSecurity  {
    const debtSecurity = new DebtSecurity(componentInstance.debtSecurity.value);
    debtSecurity.debtInstallments = componentInstance.dataSource;

    return debtSecurity;
  }

  private observeDialogResult(dialogRef: MatDialogRef<DialogComponent>) {
    dialogRef.componentInstance.getDialogResult().subscribe(
      (result: DialogResult) => {
        this.addRowData(result);
      }
    )
  }
}
