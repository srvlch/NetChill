import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  IsAdmin:boolean=false;

  constructor(private _auth:AuthService , private _route:Router) { 
    this.IsAdmin = this._auth.IsAdmin()
  }

  ngOnInit(): void {}


}
