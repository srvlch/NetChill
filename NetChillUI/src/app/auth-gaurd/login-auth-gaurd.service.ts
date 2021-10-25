import { AuthService } from '../services/auth.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class LoginAuthGaurdService implements CanActivate {

  constructor(private _auth:AuthService , private _route:Router) { }
  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean{
    if(!this._auth.isLoggedIn()){
      return true;
    }
    this._route.navigateByUrl('/dashboard');
    return false;
  }
}
