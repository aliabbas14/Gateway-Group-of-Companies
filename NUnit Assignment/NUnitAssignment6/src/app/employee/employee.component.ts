import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

   emp=[
     {"id":1, "name":"abc"},
     {"id":2, "name":"pqr"},
     {"id":3, "name":"xyz"}
    ];

  constructor() { }

  ngOnInit(): void {
  }


  async get()
  {
      return this.emp;
  }

  async getById(id:number)
  {
    return this.emp.find(x=>x.id==id);
  }

  async post(data:any)
  {
    this.emp.push(data);
    return "Employee Added";
  }

  async put(id:number,name:string)
  {
    var index=this.emp.findIndex(x=>x.id==id);
    this.emp[index].name=name;
    return "Employee Updated";
  }

  async delete(id:number)
  {
    this.emp = this.emp.filter(x => x.id != id);
    return "Employee Deleted";
  }

}
