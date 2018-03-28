import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConspectsComponent } from './conspects/conspects.component';
import { PersonalPageRoutingModule } from './personal-page-routing.module';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
@NgModule({
  imports: [
    CommonModule,
    PersonalPageRoutingModule
  ],
  providers: [ConspectsService],
  declarations: [ ConspectsComponent ]
})
export class PersonalPageModule { }
