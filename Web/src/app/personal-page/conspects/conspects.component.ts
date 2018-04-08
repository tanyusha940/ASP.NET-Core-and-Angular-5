import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';

@Component({
  selector: 'app-conspects',
  templateUrl: './conspects.component.html',
  styleUrls: ['./conspects.component.scss']
})
export class ConspectsComponent implements OnInit {

  form: FormGroup;
  conspect: Conspect;
  fb: FormBuilder;

  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.form.controls[controlName];

    const result = control.invalid && control.touched;

    return result;
  }

  private initForm() {
    this.form = this.fb.group({
      Name: ['', [
        Validators.required,
        Validators.maxLength(50)
      ]],
      SpecialityNumberId: ['', [
        Validators.required,
        Validators.max(500)
      ]],
      Content: ['', [
        Validators.required
      ]]
    });
  }
}
