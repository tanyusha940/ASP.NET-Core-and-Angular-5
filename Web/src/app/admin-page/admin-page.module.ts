import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from '@app/admin-page/admin/admin.component';
import { AdminRoutingModule } from '@app/admin-page/admin-page-routing.module';
import { UsersService } from '@app/admin-page/admin/users.service';

@NgModule({
  imports: [
    CommonModule,
    AdminRoutingModule
  ],
  declarations: [AdminComponent],
  providers: [UsersService]
})
export class AdminPageModule { }
