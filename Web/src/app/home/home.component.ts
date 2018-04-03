import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { QuoteService } from './quote.service';
import { FormGroup } from '@angular/forms';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';
import { AgWordCloudData } from 'angular4-word-cloud';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
 
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  form: FormGroup;
  conspectItems: ConspectItem[];
  tagItems: TagItem[];
  wordData:CloudData[] =[];

  constructor(
    private conspectsService: ConspectsService,
    private tagsService: TagsService
  ) {   }
  public random(): number{
      return Math.floor(Math.random() * 10);
  }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();  
    this.tagItems = await this.tagsService.getTags();
    console.log(this.getWords());
  }

  options: CloudOptions = {
    width : 1000,
    height : 400,
    overflow: false,
  }
 async getWords(){
  var data:any = [];
  this.tagItems.forEach(tag => {
    data.push({
            weight: this.random(),
            text: tag.text
          });

  });
  this.wordData = data;
  return await this.wordData;
  }
}
