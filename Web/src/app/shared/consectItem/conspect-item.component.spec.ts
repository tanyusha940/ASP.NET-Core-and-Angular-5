import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConspectItemComponent } from './conspect-item.component';

describe('ConspectItemComponent', () => {
  let component: ConspectItemComponent;
  let fixture: ComponentFixture<ConspectItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConspectItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConspectItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
