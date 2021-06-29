import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LayoutFlexComponent } from './layout-flex.component';

describe('LayoutFlexComponent', () => {
  let component: LayoutFlexComponent;
  let fixture: ComponentFixture<LayoutFlexComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LayoutFlexComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LayoutFlexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
