import { Component, OnInit } from '@angular/core';
import { AngularFireStorage } from '@angular/fire/storage';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { finalize } from 'rxjs/operators';
import { UploadingService } from 'src/app/services/uploading.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  constructor(private _storage:AngularFireStorage , private _upload:UploadingService) { }
  imgSrc:string="assets/preview.png";
  ngOnInit(): void {
  }
  selectedimg:any;
  selectedMovie:any;

  formTemplate=new FormGroup({
    Name:new FormControl(''),
    Category:new FormControl(''),
    YearOfRelease:new FormControl(''),
    AvailaibilityStarts:new FormControl(''),
    Description:new FormControl(''),
    IsFeatured:new FormControl(''),
    PosterPath:new FormControl(''),
    ContentPath:new FormControl(''),
  });

  uploading=false;
  uploadDone=false;

  ImgChange(val:any){
    if(val.target.files && val.target.files[0]){
      this.selectedimg = val.target.files[0];
      const reader = new FileReader();
      reader.onload=(e:any)=>this.imgSrc=e.target.result;
      reader.readAsDataURL(val.target.files[0]);
    }
  }

  MovieChange(val:any){
    if(val.target.files && val.target.files[0]){
      this.selectedMovie = val.target.files[0];
    }
  }

 

  async submit(val:any){
    
    if(this.formTemplate.valid){
      this.uploading=true;
      this._upload.uploadMovieData(this.selectedimg,this.selectedMovie,val.value,(err)=>{
        if(err){
          if(err.status===400 && err.error.Message) alert(err.error.Message);
          else
            alert("Error Occured Please try again.");
          this.formTemplate.reset();
          this.uploading=false;
          return;
        }
        this.uploading=false;
        this.uploadDone=true;
        setInterval(()=>this.uploadDone=false,3000)
        this.formTemplate.reset();
      });
    }
    
  }
}

