import { RegistrationComponent } from "@app/registration/registration.component";
import { extract } from "@app/core";
import { Routes, RouterModule } from "@angular/router";
import { NgModule } from '@angular/core';

const routes: Routes = [
    { path: 'registration', component: RegistrationComponent, data: { title: extract('Registration') } }
];
  
@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
    providers: []
  })

  export class RegistrationRoutingModule {}