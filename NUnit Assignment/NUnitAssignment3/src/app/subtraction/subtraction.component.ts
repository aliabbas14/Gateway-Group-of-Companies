import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtraction',
  templateUrl: './subtraction.component.html',
  styleUrls: ['./subtraction.component.css']
})
export class SubtractionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  subtraction(x,y)
  {
    if(y>x)
    {
      return 0;
    }
    return x-y;
  }
}
