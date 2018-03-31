import { Component, OnInit } from '@angular/core';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { ConspectItem } from '@app/personal-page/conspects/models/conspectItem';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Conspect } from '@app/personal-page/conspects/models/conspect';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';

@Component({
  selector: 'app-conspects',
  templateUrl: './conspects.component.html',
  styleUrls: ['./conspects.component.scss']
})
export class ConspectsComponent implements OnInit {

  form: FormGroup;
  conspectItems: ConspectItem[];
  conspect: Conspect;

  constructor(private conspectsService: ConspectsService, private fb: FormBuilder) { }

  async ngOnInit() {
    this.initForm();
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
