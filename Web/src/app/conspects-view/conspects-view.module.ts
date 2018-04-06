import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConspectListComponent } from './conspect-list/conspect-list.component';
import { ConspectsViewRoutingModule } from '@app/conspects-view/conspects-view-routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ConspectsViewRoutingModule
  ],
  declarations: [ConspectListComponent]
})
export class ConspectsViewModule { }
