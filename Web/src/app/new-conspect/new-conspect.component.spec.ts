import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewConspectComponent } from './new-conspect.component';

describe('NewConspectComponent', () => {
  let component: NewConspectComponent;
  let fixture: ComponentFixture<NewConspectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewConspectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewConspectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
