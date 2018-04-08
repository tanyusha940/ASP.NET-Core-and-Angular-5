import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { QuoteService } from './quote.service';
import { FormGroup } from '@angular/forms';
import { ConspectsService } from '@app/personal-page/conspects.service';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';
import { AgWordCloudData } from 'angular4-word-cloud';
import { TagItem } from '@app/personal-page/tags/models/tagItem';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { RatingComponent } from '@app/shared/rating/rating.component';
import { RatingItem } from '@app/shared/rating/models/ratingsItem';
import { RatingsService } from '@app/shared/rating/rating.service';
import { ConspectsListComponent } from '@app/personal-page/conspects-list/conspects-list.component';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [RatingsService]
})
export class HomeComponent implements OnInit {

  form: FormGroup;
  tagItems: LookUp[];
  wordData: CloudData[] = [];
  ratingItem: RatingItem[];
  constructor(
    private tagsService: TagsService
  ) {   }
  public random(): number {
      return Math.floor(Math.random() * 10);
  }

  async ngOnInit() {
    this.tagItems = await this.tagsService.getTags();
  }

  options: CloudOptions = {
    width : 1000,
    height : 400,
    overflow: false,
  };

 async getWords() {
  const data: any = [];
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
