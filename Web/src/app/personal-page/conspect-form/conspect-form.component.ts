import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Conspect } from '@app/personal-page/conspect-form/models/conspect';
import { ConspectsService } from '@app/personal-page/conspects.service';
import { I18nService } from '@app/core';
import { HttpClient } from '@angular/common/http';
import { LookUp } from '@app/personal-page/conspect-form/models/lookUp';
import { cloneDeep } from 'lodash';
import { Subscription } from 'rxjs/Subscription';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-conspect-form',
  templateUrl: './conspect-form.component.html',
  styleUrls: ['./conspect-form.component.scss']
})
export class ConspectFormComponent implements OnInit, OnDestroy {

  form: FormGroup;
  conspect: Conspect;
  initialState = new Conspect();
  tagOptions: LookUp[] = [];

  private subscriptions: Subscription[] = [];

  constructor(
    private conspectsService: ConspectsService,
    private fb: FormBuilder,
    private i18nService: I18nService,
    private http: HttpClient,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    if (this.route.firstChild) {
      this.subscriptions.push(this.route.firstChild.params.subscribe(params => this.loadConspect(+params['id'])));
    }
  }

  ngOnDestroy() {
    this.subscriptions.forEach(subscription => {
      if (subscription) {
        subscription.unsubscribe();
      }
    });
  }

  private loadConspect(id: number) {
    this.conspect = null;
    this.initForm();
    if (id) {
      this.conspectsService.getById(id)
        .then((data: Conspect) => this.initConspect(data));
    } else {
      this.initConspect(new Conspect());
    }
  }

  private initConspect(conspect: Conspect) {
    this.initialState = conspect;
    this.resetForm();
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
    } else {
      if (this.conspect.id > 0) {
        await this.conspectsService.updateConspect(this.conspect, this.conspect.id);
      } else {
        await this.conspectsService.createConspect(this.conspect);
      }
      this.goAwayFromForm();
    }
  }

  onCancel() {
    this.goAwayFromForm();
  }

  private goAwayFromForm() {
    this.resetForm();
    this.router.navigate(['account']);
  }

  private initForm() {
    this.form = this.fb.group({
      name: ['', [
        Validators.required,
        Validators.maxLength(50)
      ]],
      specialityNumberId: ['', [
        Validators.required,
        Validators.max(500)
      ]],
      content: ['', [
        Validators.required
      ]],
      tags: ['', [
        Validators.required
      ]]
    });
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

  async getTagsLookUps() {
     this.tagOptions = await this.http.get<LookUp[]>('/lookUp/tags').toPromise();
  }

  private resetForm() {
    this.conspect = cloneDeep(this.initialState);
    if (this.form != null) {
      this.form.markAsPristine();
      this.form.markAsUntouched();
    }
  }

  onTagAdd(tag: LookUp) {
    tag.id = +tag.id;
    if (!tag.id) {
      tag.id = 0;
    }
  }
}
