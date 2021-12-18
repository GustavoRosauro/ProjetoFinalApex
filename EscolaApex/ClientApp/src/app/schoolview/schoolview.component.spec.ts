import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolviewComponent } from './schoolview.component';

describe('SchoolviewComponent', () => {
  let component: SchoolviewComponent;
  let fixture: ComponentFixture<SchoolviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
