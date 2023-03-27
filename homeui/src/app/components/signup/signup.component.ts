import { Component,OnInit} from '@angular/core';
import { FormBuilder, FormControl, FormGroup ,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import ValidateForm from 'src/app/Helpers/validatteforms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent  implements OnInit { 
  type:string="Password";
  isText: boolean=false;
  eyeIcon:string="fa-eye-slash";
  signupForm!:FormGroup;
  router: any;
  constructor(private fb: FormBuilder,private auth:AuthService,router:Router){ }
  ngOnInit(): void {
    this.signupForm =this.fb.group(
  {
    Name:['',Validators.required],
    Email:['',Validators.required],
    Password:['',Validators.required ],
   })}
   hideShowPass(){
    this.isText=!this.isText;
    this.isText? this.eyeIcon="fa-eye": this.eyeIcon="fa-eye-slash";
   this.isText? this.type="text": this.type="Password";
   }
   onSignup (){
    if(this.signupForm.valid){
      this.auth.signUp(this.signupForm.value)
      .subscribe({
        next:(res=>{
          alert(res.message);
          this.signupForm.reset();
          this.router.navigate(['login']);

        })
        ,error:(err=>{
          alert(err?.error.message)
        })
      })
      console.log(this.signupForm.value)
      //send the obj to database 
     }
     else{
      // console.log("Form is not valid");  
      //throw the erroe using toaster and required fields   
       ValidateForm.validateAllFormFileds(this.signupForm)
       alert("Your form is invalid")
      }
    }

    


}
