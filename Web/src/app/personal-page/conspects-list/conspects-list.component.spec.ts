import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConspectsListComponent } from './conspects-list.component';

describe('ConspectsListComponent', () => {
  let component: ConspectsListComponent;
  let fixture: ComponentFixture<ConspectsListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConspectsListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConspectsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
