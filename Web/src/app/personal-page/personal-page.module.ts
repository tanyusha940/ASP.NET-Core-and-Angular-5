import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConspectsComponent } from './conspects/conspects.component';
import { PersonalPageRoutingModule } from './personal-page-routing.module';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    CommonModule,
    PersonalPageRoutingModule,
    ReactiveFormsModule 
  ],
  providers: [ConspectsService],
  declarations: [ ConspectsComponent ]
})
export class PersonalPageModule { }
