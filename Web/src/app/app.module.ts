import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {ToastModule} from 'ng2-toastr/ng2-toastr';

import { environment } from '@env/environment';
import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { LoginModule } from './login/login.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonalPageModule } from '@app/personal-page/personal-page.module';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { NgxSelectModule, INgxSelectOptions } from 'ngx-select-ex';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TagInputModule } from 'ngx-chips';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { AdminPageModule } from '@app/admin-page/admin-page.module';
import { RegistrationModule } from '@app/registration/registration.module';
import { EmailConfirmModule } from '@app/email-confirm/email-confirm.module';
import { RatingsService } from '@app/shared/rating/rating.service';



const CustomSelectOptions: INgxSelectOptions = { // Check the interface fo more options
  optionValueField: 'id',
  optionTextField: 'name'
};

@NgModule({
  imports: [
    ToastModule.forRoot(),
    BrowserModule,
    ServiceWorkerModule.register('/ngsw-worker.js', { enabled: environment.production }),
    FormsModule,
    HttpClientModule,
    TranslateModule.forRoot(),
    NgbModule.forRoot(),
    CoreModule,
    SharedModule,
    HomeModule,
    AboutModule,
    LoginModule,
    RegistrationModule,
    PersonalPageModule,
    EmailConfirmModule,
    AdminPageModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TagInputModule,
  ],
  declarations: [AppComponent],
  providers: [
    TagsService,
    RatingsService
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
