import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { BarRatingModule } from 'ngx-bar-rating';
import { RatingComponent } from '@app/shared/rating/rating.component';
import { NgxPermissionsModule } from 'ngx-permissions';
import { CustomToastrOptions } from '@app/shared/toastr/toastr-options';
import { ToastOptions } from 'ng2-toastr';

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
    RatingComponent,
  ],
  providers: [
    { provide: ToastOptions, useClass: CustomToastrOptions },
  ],
  exports: [
    LoaderComponent,
    NgxPermissionsModule,
    RatingComponent
  ]
})
export class SharedModule { }
