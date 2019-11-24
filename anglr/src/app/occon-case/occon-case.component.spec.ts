import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { OcconCaseComponent } from './occon-case.component';

describe('OcconCaseComponent', () => {
  let component: OcconCaseComponent;
  let fixture: ComponentFixture<OcconCaseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ OcconCaseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(OcconCaseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
