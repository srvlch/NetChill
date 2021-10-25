import { userData } from './../models/user';
import { environment } from './../../environments/environment';

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, OnInit } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService   {


  constructor(private http : HttpClient) {
   }
 
  SignUp(signUpUser:any){
    return this.http.post(environment.apiURL+"signup",signUpUser).toPromise();
  }


  Login(logInUser:any){
    return this.http.post(environment.apiURL+"login",logInUser).toPromise();
  }

  getToken():string{
    return (localStorage.getItem('token')?.toString() as string);
  }


  isLoggedIn():boolean{
    if(localStorage.getItem('token')){
      return true;
    }
    else{
      return false;
    }
  }

  setSession(res:userData){
    localStorage.setItem('token',res?.token);
    localStorage.setItem('IsAdmin',res?.IsAdmin?"true":"false");
  }

  IsAdmin():boolean{
    if(localStorage.getItem('IsAdmin')=="true"){
      return true;
    }
    return false;
  }

  LogOut():void{
    localStorage.clear();
  }
}
