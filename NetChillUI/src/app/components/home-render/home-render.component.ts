import { movie } from './../../models/movies';
import { Component, Input, OnInit } from '@angular/core';
import { promise } from 'protractor';
import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-home-render',
  templateUrl: './home-render.component.html',
  styleUrls: ['./home-render.component.css']
})
export class HomeRenderComponent implements OnInit {

  constructor(private _moviesService:MoviesService) { }

  upcoming:movie[]=[];
  newRelease:movie[]=[];
  featured:movie[]=[];
  pageLoaded:boolean=false;
  loadingImgPath:string="assets/giphy.gif";
  @Input('clickable') clickable:boolean=false;

  ngOnInit(): void {
      Promise.all([
        this._moviesService.getUpcomingMovies(2),
        this._moviesService.getFeaturedMovies(2),
        this._moviesService.getNewReleaseMovies(2)
      ])
      .then(res=>{
        this.upcoming=res[0] as movie[];
        this.featured=res[1] as movie[];
        this.newRelease=res[2] as movie[];
        this.pageLoaded=true;
      })
      .catch(err=>{
        
        if(err.status===0){
          alert('Server not responding.');
        }
        else if(err.status===400 && err.error.Message) alert(err.error.Message);
        else  alert(err.message);
        
      })
      
  }

 

}
