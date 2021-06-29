import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgxLoadingModule } from 'ngx-loading';

import { BreadcrumbModule } from 'xng-breadcrumb';
import { FaAwesomeModule } from '../modules/fa-awesome/fa-awesome.module';
import { MaterialModule } from '../modules/material/material.module';
import { BreadcrumbComponent } from './components/breadcrumb/breadcrumb.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { NgComponentOutletDirective } from './directives/ng-component-outlet.directive';
import { CustomLoadingComponent } from './components/custom-loading/custom-loading.component';

@NgModule({
  declarations: [
    BreadcrumbComponent,
    DialogComponent,
    NgComponentOutletDirective,
    CustomLoadingComponent
  ],
  imports: [
    CommonModule,
    BreadcrumbModule,
    MaterialModule,
    FaAwesomeModule,
    NgxLoadingModule.forRoot({})
  ],
  exports: [
    BreadcrumbComponent,
    CustomLoadingComponent
  ]
})
export class SharedModule { }
