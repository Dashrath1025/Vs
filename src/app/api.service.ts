import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class APIService {
public empurl="http://localhost:24406/api/Employee/";
public loginUrl="http://localhost:24406/api/Login/";

  constructor(private http:HttpClient) { }

  signUp(empObj:any){
  return this.http.post<any>(this.loginUrl+"signup",empObj);
  }

  login(empObj:any){
    return this.http.post<any>(this.loginUrl+"login",empObj);
  }

  GetEmployees(){
    return this.http.get<any>(`${this.empurl}get_all_employee`)
    .pipe(map((res:any)=>{
      return res;
    }))
  }

  PostEmployee(data:any){
    return this.http.post<any>(this.empurl+"add_employee",data).pipe(map((res)=>{
      return res;
    }))
  }

  UpdateEmployee(data : any){
    return this.http.put<any>(`${this.empurl}update_employee`,data)
    .pipe(map((res:any)=>{
      return res;
    }))
  }

    DeleteEmployee(id:any){
      return this.http.delete<any>(this.empurl+"delete_employee/"+id).pipe(map((res)=>{
        return res;
      }))

    }




}
