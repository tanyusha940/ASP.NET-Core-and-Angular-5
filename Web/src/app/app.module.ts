import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ServiceWorkerModule } from '@angular/service-worker';
import { TranslateModule } from '@ngx-translate/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { environment } from '@env/environment';
import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeModule } from './home/home.module';
import { AboutModule } from './about/about.module';
import { LoginModule } from './login/login.module';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { PersonalPageModule } from '@app/personal-page/personal-page.module';
import { ConspectsComponent } from '@app/personal-page/conspects/conspects.component';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { NgxSelectModule, INgxSelectOptions } from 'ngx-select-ex';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TagInputModule } from 'ngx-chips';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { NewConspectComponent } from './new-conspect/new-conspect.component';
import { NewConspectModule } from './new-conspect/new-conspect.module';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { ConspectsViewModule } from '@app/conspects-view/conspects-view.module';
import { AdminPageModule } from '@app/admin-page/admin-page.module';
import { RegistrationComponent } from './registration/registration.component';
import { RegistrationModule } from '@app/registration/registration.module';



const CustomSelectOptions: INgxSelectOptions = { // Check the interface fo more options
  optionValueField: 'id',
  optionTextField: 'name'
};

@NgModule({
  imports: [
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
    NewConspectModule,
    AdminPageModule,
    ConspectsViewModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    TagInputModule,
  ],
  declarations: [AppComponent
    ],
  providers: [
    TagsService,
  ],
  bootstrap: [
    AppComponent
  ]
})
export class AppModule { }
