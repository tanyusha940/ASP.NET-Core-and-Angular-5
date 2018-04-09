import { Component, OnInit, Input, OnDestroy } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects.service';
import { ConspectDto } from '@app/personal-page/conspects-list/models/conspectDto';
import { RatingsService } from '@app/shared/rating/rating.service';
import { RatingComponent } from '@app/shared';
import { NgModel } from '@angular/forms';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { AuthenticationService } from '@app/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown'; 

@Component({
  selector: 'app-conspects-list',
  templateUrl: './conspects-list.component.html',
  styleUrls: ['./conspects-list.component.scss'],
})
export class ConspectsListComponent implements OnInit, OnDestroy {

  @Input() url: string;
  conspects: ConspectDto[];
  rate: any = 0;
  isPreviewMode = false;
  private subscriptions: Subscription[] = [];

  constructor(private conspectsService: ConspectsService,
              private ratingsService: RatingsService,
              private authenticationService: AuthenticationService,
              private router: Router,
              private route: ActivatedRoute) {
               }

  async ngOnInit() {
    this.subscriptions.push(this.route.data.subscribe((params: any) => {
      this.url = params.url;
      this.isPreviewMode = params.isPreviewMode;
    }));
    await this.refreshConspects();
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  async refreshConspects() {
    this.conspects = await this.conspectsService.getConspects(this.url);
    console.log(this.conspects);
  }

  isButtonVisible(item: ConspectDto) {
    const username = this.authenticationService.username;
    if (!username) {
      return false;
    }

    return username === item.userName;
  }

  onEdit(item: ConspectDto) {
    const url = (item.id === null) ? 'conspect/create' : `conspect/${item.id}`;
    this.router.navigate([url]);
  }

  async onDelete(item: ConspectDto) {
    await this.conspectsService.deleteConspect(item.id);
    await this.refreshConspects();
  }

  onCreate() {
    this.router.navigate(['conspect/create']);
  }

}
