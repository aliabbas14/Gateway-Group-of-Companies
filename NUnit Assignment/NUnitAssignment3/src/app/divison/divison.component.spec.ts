import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DivisonComponent } from './divison.component';

describe('DivisonComponent', () => {
  let component: DivisonComponent;
  let fixture: ComponentFixture<DivisonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DivisonComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DivisonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should create', () => {
    expect(component.divison(10,2)==5).toBeTruthy();
  });

  it('negative', () => {
    expect(component.divison(10,0)==0).toBeTruthy();
  });
});
