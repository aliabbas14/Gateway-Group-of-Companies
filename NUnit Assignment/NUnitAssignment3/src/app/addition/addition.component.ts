import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-addition',
  templateUrl: './addition.component.html',
  styleUrls: ['./addition.component.css']
})
export class AdditionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  addition(x,y)
  {
    if(x>0 && y>0)
    {
      return x+y;
    }
    return 0;
  }
}
