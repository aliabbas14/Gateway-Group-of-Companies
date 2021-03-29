import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { CompanyService } from '../company.service';
import { Company } from '../company.model';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  id:number=0;
  companies:Company[]=[];
  company:Company=new Company();
  flag:boolean=false;
  constructor(private router:Router,private route:ActivatedRoute,private companyService:CompanyService) {

   }



  ngOnInit(): void {
    this.id=parseInt(this.route.snapshot.paramMap.get('id'));
   
         this.loadScript('assets/js/scripts.js');
         this.companyService.CompanyInit();
    this.companyService.GetCompany().subscribe((data)=>{

      
      
      this.companies=data;
      
    });

    console.log(this.companies);
    this.company=this.companies.find(x=>x.Id==this.id);
    console.log("-----"+this.companies);
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
    public deleteCompany(id:number){
      this.companies = this.companies.filter(item => item.Id != this.id);
      this.companyService.AddCompany(this.companies);
      this.router.navigate(['/list']);
    }
}
