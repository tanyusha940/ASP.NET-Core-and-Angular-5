import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { BarRatingModule } from 'ngx-bar-rating';
import { RatingComponent } from '@app/shared/rating/rating.component';

@NgModule({
  imports: [   
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
    CommonModule,
    BarRatingModule
  ],
  declarations: [
    LoaderComponent,
    ConspectItemComponent,
    RatingComponent,
    
  ],
  exports: [
    LoaderComponent,
  ]
})
export class SharedModule { }
