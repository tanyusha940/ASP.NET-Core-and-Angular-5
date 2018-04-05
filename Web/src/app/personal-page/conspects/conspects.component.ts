import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';

@Component({
  selector: 'app-conspects',
  templateUrl: './conspects.component.html',
  styleUrls: ['./conspects.component.scss'],
})
export class ConspectsComponent implements OnInit {

  conspectItems: ConspectItem[];

  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {     
    this.conspectItems = await this.conspectsService.getConspects();
  }
}
