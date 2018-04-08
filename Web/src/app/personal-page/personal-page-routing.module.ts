import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { extract, Route } from '@app/core';
import { ConspectFormComponent } from '@app/personal-page/conspect-form/conspect-form.component';
import { ConspectsListComponent } from '@app/personal-page/conspects-list/conspects-list.component';

const routes: Routes = [
  Route.withShell([
    {
      path: 'conspect',
      component: ConspectFormComponent,
      data: {
        title: extract('Personal Page'),
        create: true
      },
      children: [
        {
          path: ':id',
          component: ConspectFormComponent
        }
      ]
    },
    {
      path: 'account',
      component: ConspectsListComponent,
      data: {
        url: '/lookUp/conspects/user'
      }
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class PersonalPageRoutingModule {}
