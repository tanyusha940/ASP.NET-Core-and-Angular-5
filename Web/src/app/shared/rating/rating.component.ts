import { Component, OnInit, Input } from '@angular/core';
import { RatingsService } from '@app/shared/rating/rating.service';
import { AuthenticationService } from '@app/core';
import { ConspectDto } from '@app/personal-page/conspects-list/models/conspectDto';

@Component({
  selector: 'app-rating',
  templateUrl: './rating.component.html',
  styleUrls: ['./rating.component.scss']
})
export class RatingComponent implements OnInit {

  @Input() conspect: ConspectDto;
  rate: number;
  constructor(private service: RatingsService,
              private authService: AuthenticationService) { }

  async ngOnInit() {
    await this.setRating();
  }

  async setRating() {
    if (this.conspect.id !== null) {
      this.rate = await this.service.getRating(this.conspect.id);
      console.log(this.rate);
    }
  }

  async onRateChanged(mark: number) {
    if (await this.canUserMarkConspect()) {
    await this.service.rateConspect(this.conspect.id, mark);
    await this.setRating();
    }
  }

  isReadOnly() {
    return this.isUserUnAuthOrConspectOwner();
  }

  isUserUnAuthOrConspectOwner() {
    return  !this.authService.username || this.conspect.userName === this.authService.username;
  }

  async canUserMarkConspect() {
    return await this.service.canRateConspect(this.conspect.id);
  }

}
