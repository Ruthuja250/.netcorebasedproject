import { Component,OnInit} from '@angular/core';
import { FormBuilder, FormControl, FormGroup ,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/Helpers/validatteforms';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent  implements OnInit { 
  type:string="Password";
  isText: boolean=false;
  eyeIcon:string="fa-eye-slash";
  loginForm!:FormGroup;
  constructor(private fb: FormBuilder,private auth:AuthService, private router:Router,private userStore:UserStoreService){ }
  ngOnInit(): void {
    this.loginForm =this.fb.group(
  {
    Email:['',Validators.required],
    Password:['',Validators.required ],
   })}
   hideShowPass(){
    this.isText=!this.isText;
    this.isText? this.eyeIcon="fa-eye": this.eyeIcon="fa-eye-slash";
   this.isText? this.type="text": this.type="Password";
   }
   onLogin (){
    if(this.loginForm.valid){
      console.log(this.loginForm.value)
      this.auth.login(this.loginForm.value)
      .subscribe(
        {
          next:(res)=>{
          alert(res.message);
          this.loginForm.reset();
          this.auth.storeToken(res.token);
          const tokenPayload=this.auth.decodeToken();
          this.userStore.setNameForStore(tokenPayload.name);
          this.userStore.setRoleForStore(tokenPayload.role);
          this.router.navigate(['dashboard'])
        },
        error:(err)=>{
          alert("Something went wrong")
          console.log(err);
        },
        
        

      })
      //send the obj to database 
    }
     else{
      // console.log("Form is not valid");  
      //throw the erroe using toaster and required fields   
      ValidateForm .validateAllFormFileds(this.loginForm);
       alert("Your form is invalid")
      }
    }

  


}
