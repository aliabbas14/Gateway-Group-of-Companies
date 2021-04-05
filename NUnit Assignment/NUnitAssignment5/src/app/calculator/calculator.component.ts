import { Component, OnInit } from '@angular/core';
import { CalculatorService } from './calculator.service';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})
export class CalculatorComponent implements OnInit {

  constructor(private calc:CalculatorService) { }

  ngOnInit(): void {
  }

  addition(x:number,y:number)
  {
    return this.calc.addition(x,y);
  }

  subtraction(x:number,y:number)
  {
    return this.calc.subtraction(x,y);
  }

  multiplication(x:number,y:number)
  {
    return this.calc.multiplication(x,y);
  }

  divison(x:number,y:number)
  {
    return this.calc.divison(x,y);
  }

  square(x:number)
  {
    return this.calc.square(x);
  }
}
