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
  words: Array<AgWordCloudData>;

  constructor(
    private conspectsService: ConspectsService,
    private tagsService: TagsService
  ) { }
  public random(): number{
      return Math.floor(Math.random() * 1000);
  }

  
  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();   
    console.log(this.conspectItems);   
    this.words = await this.getWords();
  }

  async getWords(): Promise<Array<AgWordCloudData>> {
    this.tagItems = await this.tagsService.getTags();
    let wordData: Array<AgWordCloudData> = [];
    this.tagItems.forEach((tag:any) => {
      wordData.push(<AgWordCloudData>{
        size: 250,
        text: tag.text
      });
    });
    
    console.log(wordData);
    return wordData;
  }

  options = {
    settings: {
        minFontSize: 10,
        maxFontSize: 100,
    },
    margin: {
        top: 10,
        right: 10,
        bottom: 10,
        left: 10
    },
    labels: true // false to hide hover labels
};

  // options: CloudOptions = {
  //   // if width is between 0 and 1 it will be set to the size of the upper element multiplied by the value 
  //   width : 1000,
  //   height : 400,
  //   overflow: false,
  // }
 
  // data: CloudData[] = [
  //   {text: 'Weight-8-link-color', weight: 8, color: '#ffaaee'},
  //   {text: 'Weight-10-link', weight: 5},
  //   {text: 'Weight-10-link', weight: 17},
  //   {text: 'яыпink', weight: 14},
  //   {text: 'Weighяырыяп-link', weight: 10},
  //   {text: 'Weчвкр-link', weight: 8},
  //   {text: 'Weighявпыt-10-link', weight: 10},
  //   {text: 'Weight-10-link', weight: 2},
  //   {text: 'Weighыаяlink', weight: 7},
  //   // ...
  // ]
}
