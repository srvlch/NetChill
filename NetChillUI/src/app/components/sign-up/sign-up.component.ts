import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { userData } from 'src/app/models/user';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent{

  errorMsg:string="";
  processing:boolean=false;
  constructor(private _auth:AuthService,private _route:Router){}

  submit(val:any){
    if(val.valid){
      this.processing=true;
      this._auth.SignUp(val.value)
        .then((res)=>{
          this.processing=false;
          if(res){
            this._auth.setSession(res as userData);
            this._route.navigate(['/']);
          }
        })
        .catch(err=>{
          this.processing=false;
          val.controls['password'].reset();
          val.controls['ConfirmPassword'].reset();
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
