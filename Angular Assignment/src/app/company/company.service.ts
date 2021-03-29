import { Injectable } from '@angular/core';
import { Observable, throwError, BehaviorSubject } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Company } from './company.model';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private companyData=new BehaviorSubject<Company[]>([]);
  companies=this.companyData.asObservable();
  private flagData=new BehaviorSubject<boolean>(false);
  flag=this.flagData.asObservable();
  constructor(private http:HttpClient) { }
  GetCompanies():Observable<Company[]>{
    return this.http.get<Company[]>('assets/companies/company.json').pipe(
      catchError(this.errorHandler)
    );
  }
  CompanyInit(){
    console.log("Initialize");

    this.GetCompanies().subscribe((data)=>{
      this.flagData.next(true);
      this.companyData.next(data);
    });
  }
  AddCompany(c:Company[]){
    console.log("broadcast");
    this.flagData.next(true);
    this.companyData.next(c);
  }
  GetCompany():Observable<Company[]>{
    console.log("receive");
    return this.companies;
  }
  GetFlag():Observable<boolean>{
    return this.flag;
  }
  errorHandler(error:HttpErrorResponse){
    return throwError(error.message||"Server Error");
}
}
