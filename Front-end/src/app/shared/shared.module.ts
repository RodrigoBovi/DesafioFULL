import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BreadcrumbModule } from 'xng-breadcrumb';
import { FaAwesomeModule } from '../modules/fa-awesome/fa-awesome.module';
import { MaterialModule } from '../modules/material/material.module';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { NgComponentOutletDirective } from './directives/ng-component-outlet.directive';

@NgModule({
  declarations: [
    BreadcrumbComponent,
    DialogComponent,
    NgComponentOutletDirective
  ],
  imports: [
    CommonModule,
    BreadcrumbModule,
    MaterialModule,
    FaAwesomeModule
  ],
  exports: [
    BreadcrumbComponent
  ]
})
export class SharedModule { }
