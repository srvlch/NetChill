import { AuthService } from './auth.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AngularFireStorage } from '@angular/fire/storage';
import { finalize } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UploadingService {

  constructor(private _storage:AngularFireStorage,private _http:HttpClient,private _auth:AuthService) { }

uploadMovieData(selectedimg:any,selectedMovie:any,formData:any,cb:(err:any)=>void){
  let token = this._auth.getToken();
  let header = {
    headers:new HttpHeaders().set("Authorization",token?token:"" )
  }
    let fileName=`NetChill/images/${new Date().getTime()}`
    let fileRef = this._storage.ref(fileName);

     this._storage.upload(fileName,selectedimg)
      .snapshotChanges().pipe(
         finalize(async()=>{
          console.log("Image Complete upload")
          
         let imgUrl =  await fileRef.getDownloadURL().toPromise();

          var movieFileName=`NetChill/movies/${new Date().getTime()}`
          var movieRef = this._storage.ref(movieFileName);
          this._storage.upload(movieFileName,selectedMovie)
          .snapshotChanges().pipe(
            finalize(async()=>{
              console.log("Movie Complete upload")
              let movieUrl=await movieRef.getDownloadURL().toPromise();

              formData.PosterPath=imgUrl;
              formData.ContentPath=movieUrl;

              this._http.post(environment.apiURL+"uploadmovie",formData,header).toPromise()
                .then(res=>{
                  console.log(res);
                  cb(null);
                })
                  .catch((err)=>{
                    cb(err);
                  })

            })
          ).subscribe();

        })
      ).subscribe()
  }
}
