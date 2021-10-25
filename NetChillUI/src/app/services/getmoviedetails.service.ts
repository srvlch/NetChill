import { AuthService } from './auth.service';
import { environment } from './../../environments/environment';
import {  HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class GetmoviedetailsService {

  constructor(private _http:HttpClient, private _auth:AuthService) { }

  GetMovieDetails(Id:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"moviedetails/"+Id.toString(),header).toPromise();
  }

  ListMovie(Id:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"listmovie/"+Id.toString(),header).toPromise();
  }


}
