import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {

  constructor(private auth: AuthService,private router:Router) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const mytoken =this.auth.getToken();
    if(mytoken)
    {
      request=request.clone({
      setHeaders:{Authorization:`Bearer ${mytoken}`}
    })
    }
    return next.handle(request).pipe(
    catchError((err:any)=>{
      if(err instanceof HttpErrorResponse){
        if(err.status===401){}
          alert("Token is Expired Login again");
          this.router.navigate(['login'])
      }
        return throwError(()=>new Error("Some other error occured"))
     })
    );
  }
}
