import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

///Guards
import { AuthGuard } from './core/guards/auth.guard';

///Layouts
import { LayoutBlankComponent } from './layout/layout-blank/layout-blank.component';
import { LayoutFlexComponent } from './layout/layout-flex/layout-flex.component';

const routes: Routes = [
  {
    path: '',
    component: LayoutFlexComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'home',
        loadChildren: () => import('./modules/home/home.module').then(m => m.HomeModule),
        data: {
          breadcrumb: {
            label: 'Home',
            info: 'home'
          }
        }
      },
      {
        path: 'titles',
        loadChildren: () => import('./modules/titles/titles.module').then(m => m.TitlesModule),
        data: {
          breadcrumb: {
            label: 'Títulos',
            info: 'file-contract'
          }
        }
      }
    ]
  },
  {
    path: '',
    component: LayoutBlankComponent,
    children: [
      {
        path: 'login',
        loadChildren: () => import('./modules/login/login.module').then(m => m.LoginModule)
      }
    ]
  },

  // 404 Not Found page
  //{ path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
