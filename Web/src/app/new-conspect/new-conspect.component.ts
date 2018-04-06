import {  OnInit, Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';

import { environment } from '@env/environment';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';


@Component({
  selector: 'app-new-conspect',
  templateUrl: './new-conspect.component.html',
  styleUrls: ['./new-conspect.component.scss']
})
export class NewConspectComponent implements OnInit {

  version: string = environment.version;

  form: FormGroup;
  conspectItems: ConspectItem[];
  tagItems: TagItem[];
  constructor(
    private conspectsService: ConspectsService,
    private tagsService: TagsService
  ) { }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.GetSortByDateConspects();  
  }

}
