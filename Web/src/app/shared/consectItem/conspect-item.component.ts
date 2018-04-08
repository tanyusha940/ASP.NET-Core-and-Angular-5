import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NgModule } from '@angular/core';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectDto } from '@app/personal-page/conspects-list/models/conspectDto';

@Component({
  selector: 'app-conspect-item',
  templateUrl: './conspect-item.component.html',
  styleUrls: ['./conspect-item.component.scss'],
  providers: [ConspectItemComponent]
})
export class ConspectItemComponent implements OnInit {

  conspectItems: ConspectDto[];
  tagsControl = new FormControl();

  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();
  }

}
