import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';
import { AuthService } from 'src/app/services/auth.service';
import { UserStoreService } from 'src/app/services/user-store.service';
@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  
public user:any=[];
public name : string="ruthuja";
constructor(private api: ApiService,private auth:AuthService,private userStore:UserStoreService){

}
ngOnInit():void {
  this.api.getUsers()
  .subscribe(res=>{
    this.user=res;
  });
  this.userStore.getFullNameFromStore()
  .subscribe(val=>{
    let FullNameFromToken=this.auth.getNameFromToken();
    this.name=val || FullNameFromToken
  })
  
}
logout()
{
this.auth.signOut();
}
}
