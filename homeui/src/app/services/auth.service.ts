import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private baserUrl: string="https://localhost:44358/api/User/"

  constructor(private http: HttpClient,private router:Router) { }
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
}
