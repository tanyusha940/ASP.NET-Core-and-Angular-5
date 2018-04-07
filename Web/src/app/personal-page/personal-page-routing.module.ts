import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConspectsComponent } from './conspects/conspects.component';

import { extract, Route } from '@app/core';

const routes: Routes = [
    Route.withShell([
        { path: 'page', component: ConspectsComponent, data: { title: extract('Personal Page') } }
    ])
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class PersonalPageRoutingModule { }
