import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RegistrationRoutingModule } from '@app/registration/registration-routing.module';
import { RegistrationComponent } from '@app/registration/registration.component';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TranslateModule,
    NgbModule,
    RegistrationRoutingModule
  ],
  declarations: [
    RegistrationComponent
  ]
})
export class RegistrationModule { }
