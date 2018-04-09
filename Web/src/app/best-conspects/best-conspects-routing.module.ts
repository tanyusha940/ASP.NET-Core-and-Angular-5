import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { Route, extract } from '@app/core';
import { BestConspectsComponent } from '@app/best-conspects/best-conspects.component';

const routes: Routes = [
  Route.withShell([
    { path: 'best',
      component: BestConspectsComponent,
      data: {
        title: extract('Best'),
        url: '/lookUp/conspects/latest',
        isPreviewMode: true,
      }
    }
  ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class BestConspectsRoutingModule { }
