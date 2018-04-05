import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';

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
    CommonModule
  ],
  declarations: [
    LoaderComponent,
    ConspectItemComponent,
  ],
  exports: [
    LoaderComponent,
  ]
})
export class SharedModule { }
