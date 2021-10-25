import { AuthService } from './auth.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  constructor(private _http:HttpClient, private _auth:AuthService) { }

   getFeaturedMovies(limit?:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    if(limit)
    return this._http.get(environment.apiURL+"featuredmovies/"+limit.toString(),header).toPromise();

    return this._http.get(environment.apiURL+"featuredmovies",header).toPromise();
  }

  getMyListMovies(){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"mylistmovies",header).toPromise();
  }

  getUpcomingMovies(limit?:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    if(limit)
      return this._http.get(environment.apiURL+"upcomingmovies/"+limit.toString(),header).toPromise();
    return this._http.get(environment.apiURL+"upcomingmovies",header).toPromise();
  }

  getNewReleaseMovies(limit?:number){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    if(limit)
      return this._http.get(environment.apiURL+"newreleasemovies/"+limit.toString(),header).toPromise();

    return this._http.get(environment.apiURL+"newreleasemovies",header).toPromise();
  }

  
  getSimilarMovies(MovieId:number,category:string){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"similarmovies/"+MovieId.toString()+"/"+category,header).toPromise();
  }


  getSearchMovies(name:string){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"searchmovies/"+name,header).toPromise();
  }

  getTrendingMovies(){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"trendingmovies",header).toPromise();
  }

  getRecommendedMovies(){
    let token = this._auth.getToken();
    let header = {
      headers:new HttpHeaders().set("Authorization",token?token:"" )
    }
    return this._http.get(environment.apiURL+"recommendedmovies",header).toPromise();
  }

}
