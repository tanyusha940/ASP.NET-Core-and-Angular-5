import { Component, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';

import { QuoteService } from './quote.service';
import { FormGroup } from '@angular/forms';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  form: FormGroup;
  conspectItems: ConspectItem[];

  constructor(
    private conspectsService: ConspectsService,
  ) {
    
   }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();   
    console.log(this.conspectItems);   
  }
}
