import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BestConspectsComponent } from './best-conspects.component';
import { TranslateModule } from '@ngx-translate/core';
import { CoreModule } from '@app/core';
import { SharedModule } from '@app/shared';
import { PersonalPageModule } from '@app/personal-page/personal-page.module';
import { TagCloudModule } from 'angular-tag-cloud-module';
import { AgWordCloudModule } from 'angular4-word-cloud';
import { BarRatingModule } from 'ngx-bar-rating';
import { NgxPermissionsModule } from 'ngx-permissions';
import { QuoteService } from '@app/home/quote.service';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { BestConspectsRoutingModule } from '@app/best-conspects/best-conspects-routing.module';

@NgModule({
  imports: [
    CommonModule,
    TranslateModule,
    CoreModule,
    SharedModule,
    BestConspectsRoutingModule,
    PersonalPageModule,
    TagCloudModule,
    AgWordCloudModule.forRoot(),
    BarRatingModule,
    NgxPermissionsModule.forRoot()
  ],
  providers: [
    QuoteService,
    TagsService
  ],
  declarations: [BestConspectsComponent]
})
export class BestConspectsModule { }
