import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoaderComponent } from './loader/loader.component';
import { NgxPermissionsModule } from 'ngx-permissions';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    LoaderComponent
  ],
  exports: [
    LoaderComponent,
    NgxPermissionsModule
  ]
})
export class SharedModule { }
