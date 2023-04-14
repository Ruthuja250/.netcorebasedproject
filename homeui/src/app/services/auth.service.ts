import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baserUrl: string="https://localhost:44358/api/User/";
  private userPayload:any;

  constructor(private http: HttpClient,private router:Router) {
    this.userPayload=this.decodeToken();
   }
  signUp(userObj:any)
  {
    return this.http.post<any>(`${this.baserUrl}register`,userObj)

  }
  login(loginObj:any)
  {
    return this.http.post<any>(`${this.baserUrl}authenticate`,loginObj)

  }
  signOut(){
    localStorage.clear();
    this.router.navigate(['login'])
  }
  storeToken(tokenValue:string)
  {
    localStorage.setItem('token',tokenValue)
  }
  getToken()
  {
    return localStorage.getItem('token')
  }
  isLoggedIn():boolean{
    return!!localStorage.getItem('token')
  }
  decodeToken()
  {
    const jwtHelper =new JwtHelperService();
    const token=this.getToken()!;
    console.log(jwtHelper.decodeToken(token))
    return jwtHelper.decodeToken(token)
  }
  getNameFromToken()
  {
    if(this.userPayload)
    return this.userPayload.unique_name;

  }
  getRoleFromToken()
  {
    if(this.userPayload)
    return this.userPayload.role;

  }

}
