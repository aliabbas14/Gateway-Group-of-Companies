import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubtractionComponent } from './subtraction.component';

describe('SubtractionComponent', () => {
  let component: SubtractionComponent;
  let fixture: ComponentFixture<SubtractionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubtractionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubtractionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('subtraction', () => {
    expect(component.subtraction(5,3)==2).toBeTruthy();
  });

  it('greater subtraction', () => {
    expect(component.subtraction(3,5)==0).toBeTruthy();
  });
});
