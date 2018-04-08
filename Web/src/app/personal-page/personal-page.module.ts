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
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectFormComponent } from '@app/personal-page/conspect-form/conspect-form.component';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { TranslateModule } from '@ngx-translate/core';
import { ToastModule } from 'ng2-toastr';


const CustomSelectOptions: INgxSelectOptions = { // Check the interface fo more options
  optionValueField: 'id',
  optionTextField: 'name'
};
@NgModule({
  imports: [
    ToastModule.forRoot(),
    MarkdownModule.forRoot({
      provide: MarkedOptions,
      useValue: {
        gfm: true,
        tables: true,
        breaks: false,
        pedantic: false,
        sanitize: false,
        smartLists: true,
        smartypants: false,
      },
      }),
    BrowserAnimationsModule,
    TranslateModule,
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
     TagsComponent,
     ConspectFormComponent
    ],
})
export class PersonalPageModule { }
