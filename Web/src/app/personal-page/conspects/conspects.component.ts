import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { TagsComponent } from '@app/personal-page/tags/tags.component';
import { MarkdownModule, MarkedOptions } from 'ngx-markdown';
import { ConspectItemComponent } from '@app/shared/consectItem/conspect-item.component';
import { ConspectItem } from '@app/shared/consectItem/models/conspectItem';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';

@Component({
  selector: 'app-conspects',
  templateUrl: './conspects.component.html',
  styleUrls: ['./conspects.component.scss']
})
export class ConspectsComponent implements OnInit {

  form: FormGroup;
  conspectItems: ConspectItem[];
  conspect: Conspect;
  fb: FormBuilder;

  constructor(
    private conspectsService: ConspectsService,
  ) { }

  async ngOnInit() {
    this.conspectItems = await this.conspectsService.getConspects();
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.form.controls[controlName];

    const result = control.invalid && control.touched;

    return result;
  }

  async onSubmit() {
    const controls = this.form.controls;

    if (this.form.invalid) {
      Object.keys(controls)
        .forEach(controlName => controls[controlName].markAsTouched());

      return;
    }

    await this.conspectsService.createConspect(this.form.value);
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
