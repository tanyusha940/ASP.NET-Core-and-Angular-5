import { Component, OnInit } from '@angular/core';
import { TagsService } from '@app/personal-page/tags/tags.service';
import { RatingsService } from '@app/shared/rating/rating.service';
import { FormGroup } from '@angular/forms';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';
import { CloudData, CloudOptions } from 'angular-tag-cloud-module';
import { RatingItem } from '@app/shared/rating/models/ratingsItem';

@Component({
  selector: 'app-best-conspects',
  templateUrl: './best-conspects.component.html',
  styleUrls: ['./best-conspects.component.scss'],
  providers: [RatingsService]
})
export class BestConspectsComponent implements OnInit {

  form: FormGroup;
  tagItems: LookUp[];
  wordData: CloudData[] = [];
  ratingItem: RatingItem[];
  
  options: CloudOptions = {
    width : 1000,
    height : 400,
    overflow: false,
  };

  constructor(
    private tagsService: TagsService
  ) { }

  async ngOnInit() {
    this.tagItems = await this.tagsService.getTags();
    this.getWords();
  }
  public random(): number {
    return Math.floor(Math.random() * 10);
}

async getWords() {
  const data: any = [];
  this.tagItems.forEach(tag => {
    data.push({
            weight: this.random(),
            text: tag.text
          });

  });
  this.wordData = data;
  console.log(data);
  return await this.wordData;
  }

}
