import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';
import { ConspectsService } from '@app/personal-page/conspects/conspects.service';
import { I18nService } from '@app/core';
import { HttpClient } from '@angular/common/http';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';

@Component({
  selector: 'app-conspect-form',
  templateUrl: './conspect-form.component.html',
  styleUrls: ['./conspect-form.component.scss']
})
export class ConspectFormComponent implements OnInit {

  form: FormGroup;
  conspect: Conspect;
  tagOptions: LookUp[] = [];
  tags: LookUp[] = [];

  constructor(
    private conspectsService: ConspectsService,
    private fb: FormBuilder,
    private i18nService: I18nService,
    private http: HttpClient
  ) { }

  async ngOnInit() {
    this.initForm();
    this.conspect = new Conspect();
    await this.getTagsLookUps();
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
      ]],
      Tags: ['', [
        Validators.required
      ]]
    });
  }

  async createConspect() {
    await this.http.post('/conspect', {conspect: this.conspect, tags: this.tags}).toPromise();
  }

  setLanguage(language: string) {
    this.i18nService.language = language;
  }

  get currentLanguage(): string {
    return this.i18nService.language;
  }
  get languages(): string[] {
    return this.i18nService.supportedLanguages;
  }

  onTagsChanged(e: any) {
    console.log(e);
  }

  async getTagsLookUps() {
     this.tagOptions = await this.http.get<LookUp[]>('/lookUp/tags').toPromise();
  }
}
