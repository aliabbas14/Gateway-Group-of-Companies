import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdditionComponent } from './addition.component';

describe('AdditionComponent', () => {
  let component: AdditionComponent;
  let fixture: ComponentFixture<AdditionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdditionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdditionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });


  it('addition', () => {
    expect(component.addition(3,5)==8).toBeTruthy();
  });


  it('negative', () => {
    expect(component.addition(-3,5)==0).toBeTruthy();
  });

});
