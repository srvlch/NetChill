import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateChild, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminAuthGaurdService implements CanActivate {

  constructor(private _route:Router,private _auth: AuthService) { }

  
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean{

    if(this._auth.IsAdmin()==true){
      return true;
    }
    this._route.navigateByUrl("/");
    return false;
  }
}
