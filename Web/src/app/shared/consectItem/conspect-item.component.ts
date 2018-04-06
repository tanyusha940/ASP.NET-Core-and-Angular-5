import { Component, OnInit } from '@angular/core';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';

@Component({
  selector: 'app-conspect-item',
  templateUrl: './conspect-item.component.html',
  styleUrls: ['./conspect-item.component.scss'],
  providers: [ConspectItemComponent]
})
export class ConspectItemComponent implements OnInit {

  conspectItems: ConspectItem[];
  
  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();
  }

}
