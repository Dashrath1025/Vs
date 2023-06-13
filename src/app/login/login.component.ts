import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { APIService } from '../api.service';
import { UserModel } from '../user.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  public loginForm !: FormGroup;
  public loginObj = new UserModel();
constructor(private fb:FormBuilder,private http:HttpClient,private router:Router,private service:APIService) {}

  ngOnInit(): void {
     this.loginForm=this.fb.group({
      username:["",Validators.required],
      password:["",Validators.required]
     });
     localStorage.clear();

  }

  login(){
    this.loginObj.UserName=this.loginForm.value.username;
    this.loginObj.Password=this.loginForm.value.password;

    this.service.login(this.loginObj).subscribe(res=>{
      alert(res.message);
      this.router.navigate(['dashboard']);
      localStorage.setItem('token',res.token);
      localStorage.setItem('userType',res.userType)
    },err=>{
      alert("somthing went wrong")
    }
    )
  }

  
}
