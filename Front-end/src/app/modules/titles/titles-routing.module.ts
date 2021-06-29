import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { TitlesComponent } from '../../pages/titles/titles.component';

const routes: Routes = [
  {
    path: '',
    component: TitlesComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TitlesRoutingModule { }
