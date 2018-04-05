import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConspectsComponent } from './conspects/conspects.component';
import { PersonalPageRoutingModule } from './personal-page-routing.module';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from '@app/app.component';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { NgxSelectModule, INgxSelectOptions } from 'ngx-select-ex';
import { TagInputModule } from 'ngx-chips';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgxPermissionsModule } from 'ngx-permissions';


const CustomSelectOptions: INgxSelectOptions = { // Check the interface fo more options
  optionValueField: 'id',
  optionTextField: 'name'
};
@NgModule({
  imports: [

    BrowserAnimationsModule,
    TagInputModule,
    CommonModule,
    PersonalPageRoutingModule,
    ReactiveFormsModule ,
    NgxSelectModule.forRoot(CustomSelectOptions),
    NgxPermissionsModule.forRoot()
  ],
  providers: [ConspectsService],
  declarations: [
     ConspectsComponent,
     TagsComponent
    ],
})
export class PersonalPageModule { }
