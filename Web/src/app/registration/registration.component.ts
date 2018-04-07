import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { I18nService } from '@app/core';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  form: FormGroup;

  constructor(
    private router: Router,
    private i18nService: I18nService,
    private fb: FormBuilder,
  ) { }

  ngOnInit() {
    this.initForm();
  }

  private initForm() {
    this.form = this.fb.group({
      UserName: ['', [
      ]],
      Email: ['', [
      ]],
      Password: ['', [
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
  
}
