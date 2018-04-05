import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { QuoteService } from './quote.service';
import { FormGroup } from '@angular/forms';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';
import { AgWordCloudData } from 'angular4-word-cloud';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';
import { RatingComponent } from '@app/shared/rating/rating.component';
import { RatingItem } from '@app/shared/rating/models/ratingsItem';
import { RatingsService } from '@app/shared/rating/rating.service';
 
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [RatingsService]
})
export class HomeComponent implements OnInit {

  rate: any = 0;
  form: FormGroup;
  conspectItems: ConspectItem[];
  tagItems: TagItem[];
  wordData:CloudData[] =[];
  ratingItem: RatingItem[];
  //rating: RatingItem = new RatingItem();
  
  constructor(
    private conspectsService: ConspectsService,
    private tagsService: TagsService,
    private ratingsService: RatingsService
  ) {   }
  public random(): number{
      return Math.floor(Math.random() * 10);
  }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();  
    this.tagItems = await this.tagsService.getTags();
    this.ratingItem = await this.ratingsService.getRating(2);
   // console.log(this.ratingItem)
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
            text: tag.value
          });

  });
  this.wordData = data;
  return await this.wordData;
  }
}
