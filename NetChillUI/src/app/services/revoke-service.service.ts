import { AuthService } from './auth.service';
import { environment } from './../../environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RevokeServiceService {

  constructor(private _http:HttpClient, private _auth:AuthService) { }


  GetUsersByName(name:string){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"getusers/"+name,header).toPromise();
  }

  RevokeUserById(id:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"usertoberevoke/"+id,header).toPromise();
  }
}
