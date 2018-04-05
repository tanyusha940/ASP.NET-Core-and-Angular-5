import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConspectListComponent } from './conspect-list.component';

describe('ConspectListComponent', () => {
  let component: ConspectListComponent;
  let fixture: ComponentFixture<ConspectListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConspectListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConspectListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
