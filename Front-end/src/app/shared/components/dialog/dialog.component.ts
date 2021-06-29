import { Component, Inject, OnInit, Optional, ViewChild } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { DialogResult } from '../../../data/dialog/types/dialog-result';
import { Dialog } from '../../../data/dialog/types/dialog';
import { NgComponentOutletDirective } from '../../directives/ng-component-outlet.directive';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  @ViewChild('outlet') outlet: NgComponentOutletDirective<any>;

  localData: Dialog;

  private dialogResult = new Subject<DialogResult>();

  constructor(
    @Optional() @Inject(MAT_DIALOG_DATA) private data: Dialog,
    private dialogRef: MatDialogRef<DialogComponent>
  ) {
    this.localData = data;
  }

  ngOnInit(): void {
  }

  getDialogResult(): Observable<any> {
    return this.dialogResult.asObservable();
  }

  onClose() {
    this.dialogRef.close();
  }

  onConfirm() {
    this.dialogResult.next({
      componentInstance: this.outlet.component,
      event: this.localData.action
    });
  }
}
