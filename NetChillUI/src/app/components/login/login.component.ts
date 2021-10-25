import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { userData } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  errorMsg:string="";
  submitting:boolean=false;
  constructor(private _auth:AuthService,private _route:Router) { }

  ngOnInit(): void {
  }

  submit(val:any){
    if(val.valid){
      this.submitting=true;
      this._auth.Login(val.value)
      .then((res)=>{
        val.controls['password'].reset();
        this.submitting=false;
      if(res){
        this._auth.setSession(res as userData);
        this._route.navigateByUrl('/');
      }})
      .catch(err=>{
        val.controls['password'].reset();
        this.submitting=false;
        if(err.status===400 && err.error.Message){
          this.errorMsg=err.error.Message;
          setInterval(()=>{
            this.errorMsg="";
          },5000);
        }
        else if(err.status===0) alert("Server not Responding.");
        else alert(err.message);
      });
      
    }
  }

}
