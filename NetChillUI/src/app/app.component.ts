import { AuthService } from './services/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'NetChillUI';
  isLoggedIn:boolean=false;
  constructor(private _auth:AuthService , private _route : Router){
  }
  ngOnInit(){   
    this.isLoggedIn=this._auth.isLoggedIn();
  }

  logout(){
    this._auth.LogOut();
    this.isLoggedIn=this._auth.isLoggedIn();
    this._route.navigateByUrl('/anonomous');
  }
  ngDoCheck(){
    this.isLoggedIn=this._auth.isLoggedIn();
  }

  search(val:any){
    if(val.valid){
      this._route.navigateByUrl("moviesearch/"+val.value);
    }
  }
}
