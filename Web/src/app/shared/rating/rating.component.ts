import { Component, OnInit, Input } from '@angular/core';
import { RatingsService } from '@app/shared/rating/rating.service';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit {

  @Input() conspectId: number;
  rate: any = 0;
  constructor(private service: RatingsService) { }

  async ngOnInit() {
    await this.getRating();
  }

  async getRating() {
    if (this.conspectId !== null) {
      this.rate = await this.service.getRating(this.conspectId);
    }
  }

}
