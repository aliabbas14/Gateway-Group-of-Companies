import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
 
  async getUsers():Promise<Observable<any>>
  {
    return this.http.get<any>("https://jsonplaceholder.typicode.com/posts");
  }

  async getUser(id:number): Promise<Observable<any>> {
    return this.http.get(`https://jsonplaceholder.typicode.com/posts/${id}`);
  }

  async addUser(): Promise<Observable<any>> {
   return this.http.post<any>(`https://jsonplaceholder.typicode.com/posts`, {id:3,userId:1,title:"abc",body:"xyz"});
  }

  async updateUser(): Promise<Observable<any>>{
    return this.http.put<any>(`https://jsonplaceholder.typicode.com/posts/2`, {id:2,userId:1,title:"abc",body:"xyz"});
  }
  async deleteUser(id:number): Promise<Observable<any>>{
    return this.http.delete<any>(`https://jsonplaceholder.typicode.com/posts/${id}`);
  }
  
}
