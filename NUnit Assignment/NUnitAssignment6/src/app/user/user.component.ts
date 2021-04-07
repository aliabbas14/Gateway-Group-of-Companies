import { Component, OnInit } from '@angular/core';
import { UserService } from './user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  constructor(private service:UserService) { }

   ngOnInit(): void {
    //console.log(this.service.getUsers());

    
    
  }

  async getUsers()
  {
    return (await this.service.getUsers()).subscribe((data)=>{
      console.log(data);
      
  });
  }


  async getUser(id:number)
  {
    return (await this.service.getUser(id)).subscribe((data)=>{
      console.log(data);  
  });
  }

  async addUser()
  {
    return (await this.service.addUser()).subscribe((data)=>{
      console.log(data);  
  });
  }

  async updateUser()
  {
    return (await this.service.updateUser()).subscribe((data)=>{
      console.log(data);  
  });
  }


  async deleteUser(id:number)
  {
    return (await this.service.deleteUser(id)).subscribe((data)=>{
      console.log(data);  
  });
  }




}
