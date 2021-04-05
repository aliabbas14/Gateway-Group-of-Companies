import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CalculatorService {

  constructor() { }

  addition(x:number,y:number)
  {
    return x+y;
  }

  subtraction(x:number,y:number)
  {
    return x-y;
  }

  multiplication(x:number,y:number)
  {
    return x*y;
  }

  divison(x:number,y:number)
  {
    return x/y;
  }

  square(x:number)
  {
    return x*x;
  }
}
