import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculatorComponent } from './calculator.component';
import { CalculatorService } from './calculator.service';

describe('CalculatorComponent', () => {
  let component: CalculatorComponent;
  let fixture: ComponentFixture<CalculatorComponent>;
  let service:CalculatorService;
  let spy:any;

  

  beforeEach(() => {
    service = new CalculatorService();
    component = new CalculatorComponent(service);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  
  
  it('addition', () => {
    spy = spyOn(service, 'addition').and.returnValue(5);
    expect(component.addition(2,3)==5).toBeTruthy();
    expect(service.addition).toHaveBeenCalled();
  });

  it('subtraction', () => {
    spy = spyOn(service, 'subtraction').and.returnValue(8);
    expect(component.subtraction(10,2)==8).toBeTruthy();
    expect(service.subtraction).toHaveBeenCalled();
  });

  it('multiplication', () => {
    spy = spyOn(service, 'multiplication').and.returnValue(10);
    expect(component.multiplication(5,2)==10).toBeTruthy();
    expect(service.multiplication).toHaveBeenCalled();
  });

  it('divison', () => {
    spy = spyOn(service, 'divison').and.returnValue(10);
    expect(component.divison(20,2)==10).toBeTruthy();
    expect(service.divison).toHaveBeenCalled();
  });

  it('square', () => {
    spy = spyOn(service, 'square').and.returnValue(25);
    expect(component.square(5)==25).toBeTruthy();
    expect(service.square).toHaveBeenCalled();
  });

});
