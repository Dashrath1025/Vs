import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { LoginComponent } from './login/login.component';
import { EmployeeComponent } from './employee/employee.component';
import { AuthGuard } from './auth.guard';

const routes: Routes = [

  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'signup',component:SignupComponent},
  {path:'login',component:LoginComponent},
  {path:'dashboard',component:EmployeeComponent,canActivate:[AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
