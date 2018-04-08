import { Component, OnInit, Input } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { Conspect } from '@app/personal-page/conspects-list/models/conspect';
import { RatingsService } from '@app/shared/rating/rating.service';
import { RatingComponent } from '@app/shared';
import { NgModel } from '@angular/forms';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-conspects-list',
  templateUrl: './conspects-list.component.html',
  styleUrls: ['./conspects-list.component.scss'],
})
export class ConspectsListComponent implements OnInit {

  @Input() url: string;
  conspects: Conspect[];
  rate: any = 0;

  constructor(private conspectsService: ConspectsService,
              private ratingsService: RatingsService) { }

  async ngOnInit() {
    await this.refreshConspect();
  }

  async refreshConspect() {
    this.conspects = await this.conspectsService.getConspects(this.url);
  }

}
