import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from '@app/admin-page/admin/admin.component';
import { AdminRoutingModule } from '@app/admin-page/admin-page-routing.module';
import { UsersService } from '@app/admin-page/admin/users.service';
import { I18nService } from '@app/core';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    AdminRoutingModule
  ],
  declarations: [AdminComponent],
  providers: [UsersService,
    I18nService]
})
export class AdminPageModule { }
