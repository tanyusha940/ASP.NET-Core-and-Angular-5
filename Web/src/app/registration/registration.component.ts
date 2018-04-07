import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { I18nService } from '@app/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';

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
        Validators.required
      ]],
      Email: ['', [
        Validators.required,
        Validators.email
      ]],
      Password: ['', [
        Validators.required,
        Validators.pattern(/[a-zA-Z0-9]/),
        Validators.min(6)
      ]],
      RepeatPassword:['',[
        Validators.required,
        this.matchOtherValidator('Password')
      ]]
    });
  }

  matchOtherValidator (otherControlName: string) {

    let thisControl: FormControl;
    let otherControl: FormControl;
  
    return function matchOtherValidate (control: FormControl) {
  
      if (!control.parent) {
        return null;
      }
  
      // Initializing the validator.
      if (!thisControl) {
        thisControl = control;
        otherControl = control.parent.get(otherControlName) as FormControl;
        if (!otherControl) {
          throw new Error('matchOtherValidator(): other control is not found in parent group');
        }
        otherControl.valueChanges.subscribe(() => {
          thisControl.updateValueAndValidity();
        });
      }
  
      if (!otherControl) {
        return null;
      }
  
      if (otherControl.value !== thisControl.value) {
        return {
          matchOther: true
        };
      }
  
      return null;
  
    }
  
  }

  isControlInvalid(controlName: string): boolean {
    const control = this.form.controls[controlName];
    const result = control.invalid && control.touched;
    return result;
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
