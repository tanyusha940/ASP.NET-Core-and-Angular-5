import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';

import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home.component';
import { QuoteService } from './quote.service';
import { TagCloudModule } from 'angular-tag-cloud-module';
import {AgWordCloudModule} from 'angular4-word-cloud';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { BarRatingModule } from  "ngx-bar-rating";
import { NgxPermissionsModule } from 'ngx-permissions';
@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    CoreModule,
    SharedModule,
    HomeRoutingModule,
    TagCloudModule,
    AgWordCloudModule.forRoot(),
    BarRatingModule,
    NgxPermissionsModule.forRoot()
  ],
  declarations: [
    HomeComponent
  ],
  providers: [
    QuoteService,
    TagsService
  ]
})
export class HomeModule { }
