import {  OnInit, Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';

import { environment } from '@env/environment';
import { Conspect } from '@app/personal-page/conspects-list/models/conspect';


@Component({
  selector: 'app-new-conspect',
  templateUrl: './new-conspect.component.html',
  styleUrls: ['./new-conspect.component.scss']
})
export class NewConspectComponent implements OnInit {

  version: string = environment.version;

  form: FormGroup;
  conspectItems: Conspect[];
  tagItems: TagItem[];
  constructor(
    private conspectsService: ConspectsService,
    private tagsService: TagsService
  ) { }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.GetSortByDateConspects();
  }

}
