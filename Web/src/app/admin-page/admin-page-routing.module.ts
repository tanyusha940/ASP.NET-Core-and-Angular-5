import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Route, extract } from '@app/core';
import { NgxPermissionsGuard } from 'ngx-permissions';
import { AdminComponent } from '@app/admin-page/admin/admin.component';

const routes: Routes = [
  Route.withShell([
    {
      path: 'admin',
      component: AdminComponent,
      data: {
        title: extract('Admin'),
        // permissions: {
        //   only: 'admin'
        // }
      },
    //   canActivate: [NgxPermissionsGuard],
    }]
  )];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: []
})
export class AdminRoutingModule { }
