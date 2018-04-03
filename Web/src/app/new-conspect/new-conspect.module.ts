import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { NewConspectRoutingModule } from './new-conspect-routing.module';
import { NewConspectComponent } from './new-conspect.component';
@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    NewConspectRoutingModule
  ],
  declarations: [NewConspectComponent]
})

export class NewConspectModule { }
