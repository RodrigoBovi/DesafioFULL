import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from '../app-routing.module';
import { FaAwesomeModule } from '../modules/fa-awesome/fa-awesome.module';
import { MaterialModule } from '../modules/material/material.module';
import { LayoutBlankComponent } from './layout-blank/layout-blank.component';
import { LayoutFlexComponent } from './layout-flex/layout-flex.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { ToolbarComponent } from './toolbar/toolbar.component';

@NgModule({
  declarations: [
    LayoutBlankComponent,
    LayoutFlexComponent, 
    SidenavComponent,
    ToolbarComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    MaterialModule,
    FaAwesomeModule
  ]
})
export class LayoutModule { }
