import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppMasterComponent } from './app-master.component';

describe('AppMasterComponent', () => {
  let component: AppMasterComponent;
  let fixture: ComponentFixture<AppMasterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppMasterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
