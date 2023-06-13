import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {HttpClient} from "@angular/common/http"
import { Router } from '@angular/router';
import { APIService } from '../api.service';
import { UserModel } from '../user.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
      constructor(private fb: FormBuilder,private http:HttpClient,private router:Router,private service:APIService){}
      public SignUpForm !: FormGroup;
      public signupObj = new UserModel();

    ngOnInit(): void {
  this.SignUpForm=this.fb.group({
    fullname:["",Validators.required],
    mobile:["",Validators.required],
    username:["",Validators.required],
    password:["",Validators.required],
    usertype:["",Validators.required]
  })
    }

    SignUp(){

      this.signupObj.FullName = this.SignUpForm.value.fullname;
      this.signupObj.UserName = this.SignUpForm.value.username;
      this.signupObj.Password = this.SignUpForm.value.password;
      this.signupObj.UserType = this.SignUpForm.value.usertype;
      this.signupObj.Mobile = this.SignUpForm.value.mobile
      this.service.signUp(this.signupObj).subscribe(res=>{
        alert(res.message);
        this.SignUpForm.reset();
        this.router.navigate(['login'])
      })
    }
}
