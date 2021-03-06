import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { Input} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { I18nService } from '@app/core';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss'],
  providers: [TagsService]
})
export class TagsComponent implements OnInit {

  form = new FormGroup({
  tagItems:new FormControl
  })
  
  tagItems: TagItem[];
  tagItemsNew: any = [];

  constructor(
    public tagsService: TagsService,
    private i18nService: I18nService
  ) { }

  public autocompleteItems: any;
  async ngOnInit() {
    this.tagItems = await this.tagsService.getTags();
    for(let i=0; i<this.tagItems.length; i++){
      this.tagItemsNew.push(this.tagItems[i].value);
    }
    this.autocompleteItems = this.tagItems;
  }
  setLanguage(language: string) {
    this.i18nService.language = language;
  }

  get currentLanguage(): string {
    return this.i18nService.language;
  }
  get languages(): string[] {
    return this.i18nService.supportedLanguages;
  }
}
