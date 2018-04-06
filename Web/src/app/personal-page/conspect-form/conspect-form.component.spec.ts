import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConspectFormComponent } from './conspect-form.component';

describe('ConspectFormComponent', () => {
  let component: ConspectFormComponent;
  let fixture: ComponentFixture<ConspectFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConspectFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConspectFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
