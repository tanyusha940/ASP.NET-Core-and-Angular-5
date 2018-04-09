import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { extract, Route } from '@app/core';
import { ConspectFormComponent } from '@app/personal-page/conspect-form/conspect-form.component';
import { ConspectsListComponent } from '@app/personal-page/conspects-list/conspects-list.component';
import { NgxPermissionsGuard } from 'ngx-permissions';

const routes: Routes = [
  Route.withShell([
    {
      path: 'conspect',
      component: ConspectFormComponent,
      data: {
        title: extract('Personal Page'),
        create: true,
        permissions: {
          only: ['user', 'admin']
        }
      },
      canActivate: [NgxPermissionsGuard],
      children: [
        {
          path: ':id',
          component: ConspectFormComponent,
          data: {
            permissions: {
              only: ['user', 'admin']
            }
          },
          canActivate: [NgxPermissionsGuard],
        }
      ]
    },
    {
      path: 'account',
      component: ConspectsListComponent,
      data: {
        url: '/lookUp/conspects/user',
        permissions: {
          only: ['user', 'admin']
        }
      },
      canActivate: [NgxPermissionsGuard],
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class PersonalPageRoutingModule {}
