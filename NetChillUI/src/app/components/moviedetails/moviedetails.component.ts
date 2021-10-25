import { movieDeatils } from './../../models/movieDetails';
import { MoviesService } from 'src/app/services/movies.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { GetmoviedetailsService } from 'src/app/services/getmoviedetails.service';

@Component({
  selector: 'app-moviedetails',
  templateUrl: './moviedetails.component.html',
  styleUrls: ['./moviedetails.component.css']
})
export class MoviedetailsComponent implements OnInit {

  data:any;
  listButtonText:string = "Add to List";
  similarMovies:any;
  pageLoaded:boolean=false;
  loadingImgPath:string="assets/giphy.gif";
  constructor(private _route : ActivatedRoute, 
    private _getMovies:MoviesService ,
    private _getDetails:GetmoviedetailsService,
    private _router:Router) {
   }

  async ngOnInit() {
     this._route.paramMap.subscribe((async para=>{
       try{
        let Id = para.get('id');
        if(Id){
         const MovieData:any =  await this._getDetails.GetMovieDetails(parseInt(Id));
         if(MovieData){
          this.data = MovieData;
          this.listButtonText = this.data.IsListed?"Added":"Add to List";
          this.pageLoaded=true;
         }
         else this._router.navigateByUrl('/');
         this.similarMovies = await this._getMovies.getSimilarMovies(MovieData.Id,MovieData.Category);
        }
  
        else{
           this._router.navigateByUrl('/');
        }
       }
       catch(err){
        if(err.status===0){
          alert('Server not responding.');
        }
        else if(err.status===400 && err.error.Message) alert(err.error.Message);
        else  alert(err.message);
       }
      
     }));
     
     
  }


  async AddToList(){
    
    await this._getDetails.ListMovie(this.data.Id);
    
    this.listButtonText = this.listButtonText=="Add to List"?"Added":"Add to List";
    
  }



}
