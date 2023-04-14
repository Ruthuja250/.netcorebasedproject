import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './components/about/about.component';
import { CalcuatorComponent } from './components/calcuator/calcuator.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FAQComponent } from './components/faq/faq.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'Home',component:HomeComponent},
  {path:'calcuator',component:CalcuatorComponent},
  {path:'FAQ',component:FAQComponent},
  {path:'About',component:AboutComponent},
  {path:'dashboard',component:DashboardComponent,canActivate :[AuthGuard]}


  
 /* {path:'login', component:LoginComponent},
  {path:'signup',component:signupComponent},*/
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export default class AppRoutingModule { }
