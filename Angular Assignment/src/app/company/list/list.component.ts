import { Component, OnInit } from '@angular/core';
import { Company } from '../company.model';
import { CompanyService } from '../company.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {

  constructor(private companyService:CompanyService) { }
  companies:Company[]=[];
  flag:boolean=false;
  ngOnInit(): void {
    this.loadScript('/assets/js/datatables-demo.js');
    this.loadScript('assets/js/scripts.js');

    this.companyService.GetCompany().subscribe((data)=>{
      this.companies=data;
      this.companyService.GetFlag().subscribe((data)=>{
        this.flag=data;
        if(this.flag==false){
          this.companyService.CompanyInit();
        }
      });
    });

  }
  public loadScript(url: string) {
    const body = <HTMLDivElement> document.body;
    const script = document.createElement('script');
    script.innerHTML = '';
    script.src = url;
    script.async = false;
    script.defer = true;
    body.appendChild(script);
    }
}
