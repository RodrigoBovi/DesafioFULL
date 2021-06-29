import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { FormDebtInstallmentComponent } from '../../pages/titles/components/form-debt-installment/form-debt-installment.component';
import { FormDebtSecurityComponent } from '../../pages/titles/components/form-debt-security/form-debt-security.component';
import { TitlesComponent } from '../../pages/titles/titles.component';
import { SharedModule } from '../../shared/shared.module';
import { MaterialModule } from '../material/material.module';
import { TitlesRoutingModule } from './titles-routing.module';

@NgModule({
  declarations: [
    TitlesComponent,
    FormDebtSecurityComponent,
    FormDebtInstallmentComponent
  ],
  imports: [
    CommonModule,
    TitlesRoutingModule,
    MaterialModule,
    FontAwesomeModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class TitlesModule { }
