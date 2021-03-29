import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-divison',
  templateUrl: './divison.component.html',
  styleUrls: ['./divison.component.css']
})
export class DivisonComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }


  divison(x,y)
  {
    if(x>0 && y>0)
    {
      return x/y;
    }
    return 0;
  }
}
