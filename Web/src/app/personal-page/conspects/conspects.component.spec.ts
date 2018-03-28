import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConspectsComponent } from './conspects.component';

describe('ConspectsComponent', () => {
  let component: ConspectsComponent;
  let fixture: ComponentFixture<ConspectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConspectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConspectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
