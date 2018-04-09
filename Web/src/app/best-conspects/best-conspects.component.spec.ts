import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BestConspectsComponent } from './best-conspects.component';

describe('BestConspectsComponent', () => {
  let component: BestConspectsComponent;
  let fixture: ComponentFixture<BestConspectsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BestConspectsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BestConspectsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
