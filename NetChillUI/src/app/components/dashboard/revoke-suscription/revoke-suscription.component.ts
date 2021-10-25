import { RevokeServiceService } from './../../../services/revoke-service.service';
import { Component, OnInit } from '@angular/core';
import { error } from 'protractor';

@Component({
  selector: 'app-revoke-suscription',
  templateUrl: './revoke-suscription.component.html',
  styleUrls: ['./revoke-suscription.component.css']
})
export class RevokeSuscriptionComponent implements OnInit {

  users:any;
  inProgress:boolean=false;
  btnText:string = "Revoke";
  constructor(private _revokesur:RevokeServiceService) { 
  }

  ngOnInit(): void {

  }
  submit(val:any){
    this.inProgress=true;
    this._revokesur.GetUsersByName(val.value.userName).then((data)=>{
      this.users = data;
      this.inProgress=false;
    })
    .catch((err)=>{
      
      if(err.status===404)
        alert("Not Found")
      else if(err.status===0)
        alert("Server not responding. please try again.");
      else if(err.status===400 && err.error.Message) alert(err.error.Message);
      else
        alert(err.message);
      this.users=null;
      val.resetForm();
      this.inProgress=false;
    })
  }

  revoke(Id:number,event:any){
    this._revokesur.RevokeUserById(Id)
      .then(()=>{
        event.target.innerHTML=(event.target.innerHTML=="Revoke")?"Revoked":"Revoke";
      })
        .catch(err=>{
        if(err.status===0)
        alert("Server not responding. please try again.");
        else if(err.status===400 && err.error.Message) alert(err.error.Message);
        else
          alert(err.message);
        });
    
  }

}
