import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Conspect } from '@app/personal-page/conspects/models/conspect';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { Input} from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss'],
  providers: [TagsService]
})
export class TagsComponent implements OnInit {

  form: FormGroup;
  tagItems: TagItem[];
  tagItemsNew: any = [];
  public ngxValue: any = ['a','x'];
  public ngxDisabled = false;
 // @Input() Tags
  constructor(
    private tagsService: TagsService,
  ) { }

  async ngOnInit() {
    this.tagItems = await this.tagsService.getTags();
    for(let i=0; i<this.tagItems.length; i++){
      this.tagItemsNew.push(this.tagItems[i].text);
    }
  }

}
