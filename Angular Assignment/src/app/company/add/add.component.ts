import { Component, OnInit } from '@angular/core';
import { NgForm, FormControl, Validators, FormGroup } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';
import { Company } from '../company.model';
import { CompanyService } from '../company.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {
  isError:boolean=false;
  errorMessage='';
  
  constructor(private companyService:CompanyService,private route:Router) { }
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
  matcher = new ErrorStateMatcher();
company:Company=new Company();
companies:Company[]=[];
flag:boolean=false;
  ngOnInit(): void {
    this.loadScript('assets/js/scripts.js');
    console.log(this.companies);

    this.companyService.GetCompany().subscribe((data)=>{
      this.companies=data;
      this.companyService.GetFlag().subscribe((data)=>{
        this.flag=data;
        if(this.flag==false){
          this.companyService.CompanyInit();
        }
      });
    });
    console.log(this.companies);

  }
OnSubmit(){
  console.log(this.companies);
  this.company.TotalBranch=0;
 
  let max = 0;

  this.companies.forEach(character => {
    if (character.Id > max) {
      max = character.Id;
    }
  });
  this.company.Id=max+1;
 
  this.companies.push(this.company);

  this.companyService.AddCompany(this.companies);
  this.route.navigate(['/list']);
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
