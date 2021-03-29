import { Component, OnInit } from '@angular/core';
import { Company } from '../company.model';
import { ActivatedRoute ,Router} from '@angular/router';
import { CompanyService } from '../company.service';
import { ErrorStateMatcher } from '@angular/material/core';
import { NgForm, FormControl, Validators, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  isError:boolean=false;
  errorMessage='';
  id:number=0;
  companies:Company[]=[];
  company:Company=new Company();
  
  constructor(private router:Router,private route:ActivatedRoute,private companyService:CompanyService) { }
  RequiredValidationName= new FormControl('',[
    Validators.required
  ]);
  RequiredValidationEmail= new FormControl('',[
    Validators.required
  ]);
  RequiredValidationAddress= new FormControl('',[
    Validators.required,
  ]);
  RequiredValidationTotalEmployee= new FormControl('',[
    Validators.required,
  ]);
  RequiredValidationStatus= new FormControl('',[
    Validators.required,
  ]);
  companyForm: FormGroup = new FormGroup({
    Name: this.RequiredValidationName,
    Email:this.RequiredValidationEmail,
    Address:this.RequiredValidationAddress,
    TotalEmployee:this.RequiredValidationTotalEmployee,
    Status:this.RequiredValidationStatus
  });
  flag:boolean=false;
  matcher = new ErrorStateMatcher();
  
  RequiredValidationBranchName= new FormControl('',[
    Validators.required,
  ]);
  RequiredValidationBranchAddress= new FormControl('',[
    Validators.required,
  ]);
  branchForm: FormGroup = new FormGroup({
    BranchName:this.RequiredValidationBranchName,
    Address:this.RequiredValidationBranchAddress
  });
  ngOnInit(): void {
    this.id=parseInt(this.route.snapshot.paramMap.get('id'));
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
    this.company=this.companies.find(x=>x.Id==this.id);
   
    console.log(this.company);
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
    OnSubmit(){
      console.log(this.companies);

      let index=this.companies.findIndex(x=>x.Id==this.id);
      this.companies[index].Name=this.company.Name;
      this.companies[index].Email=this.company.Email;
      this.companies[index].Address=this.company.Address;
      this.companies[index].TotalEmployee=this.company.TotalEmployee;
      this.companies[index].IsCompanyActive=this.company.IsCompanyActive;
      
      this.companyService.AddCompany(this.companies);
      this.router.navigate(['/list']);
    }
   
}
