import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { IMaskModule } from 'angular-imask';
import { NgxCurrencyModule } from "ngx-currency";

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    IMaskModule,
    NgxCurrencyModule
  ],
  exports: [
    IMaskModule,
    NgxCurrencyModule
  ]
})
export class MaskModule { }
