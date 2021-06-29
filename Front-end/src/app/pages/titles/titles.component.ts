import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

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
export class TitlesComponent implements OnInit, OnDestroy {

  @ViewChild(MatTable, { static: true }) table: MatTable<DebtSecurityDataSource>;

  currentUser = JSON.parse(localStorage.getItem('user'));
  dataSource: DebtSecurityDataSource[] = [];
  dialogRef: MatDialogRef<DialogComponent, any>;
  displayedColumns: string[] = ['debtSecurityId', 'debtorName', 'numberInstallments', 'originalValue', 'daysOverdue', 'updatedAmount'];
  isSubmited = false;

  private unsubscribe$ = new Subject<void>();

  constructor(
    private dialog: MatDialog,
    private debtSecurityService: DebtSecurityService
  ) { }

  ngOnInit(): void {
    this.getDebtSecurities();
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

    this.createDebtSecurity(this.setData(result.componentInstance));
  }

  private closeDialog() {
    this.dialogRef.close();
  }

  private createDebtSecurity(body: DebtSecurity) {
    this.setLoading(true);
    this.debtSecurityService.createDebtSecurity(body).subscribe(
      data => {
        this.setLoading(false);
        this.dataSource = data;

        this.table.renderRows();
        this.closeDialog();
      },
      error => {
        this.setLoading(false);

        this.closeDialog();
      }
    )
  }

  private getDebtSecurities() {
    this.debtSecurityService.getUserDebtSecurities(this.currentUser.user.userId).subscribe(
      data => {
        this.dataSource = data;
      },
      error => { }
    )
  }

  private observeDialogResult(dialogRef: MatDialogRef<DialogComponent>) {
    dialogRef.componentInstance.getDialogResult().pipe(takeUntil(this.unsubscribe$)).subscribe(
      (result: DialogResult) => {
        this.addRowData(result);
      }
    )
  }

  private setData(componentInstance: FormDebtSecurityComponent): DebtSecurity {
    const debtSecurity = new DebtSecurity(componentInstance.debtSecurity.value);
    debtSecurity.debtInstallments = componentInstance.dataSource;
    debtSecurity.userId = this.currentUser.user.userId;

    return debtSecurity;
  }

  private setLoading(loading: boolean) {
    this.isSubmited = loading;
  }

  ngOnDestroy() {
    this.dialogRef = null;
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
