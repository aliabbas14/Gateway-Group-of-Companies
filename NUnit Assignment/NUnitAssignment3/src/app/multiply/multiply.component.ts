import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-multiply',
  templateUrl: './multiply.component.html',
  styleUrls: ['./multiply.component.css']
})
export class MultiplyComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  multiply(a,b){
    if(a!=0&&b!=0)
      return a*b;
    else
      return 0;

  }
  
}
