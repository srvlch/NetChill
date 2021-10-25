import { movie } from './../../../models/movies';
import { Component, OnInit } from '@angular/core';
import { MoviesService } from 'src/app/services/movies.service';

@Component({
  selector: 'app-newrelease',
  templateUrl: './newrelease.component.html',
  styleUrls: ['./newrelease.component.css']
})
export class NewreleaseComponent implements OnInit {

  constructor(private _getFeaturedmovies:MoviesService) { 
  }
  pageNo:number=1;
  total:number=0;
  movies:movie[]=[];
  selectedMovies:movie[]=[];
  loadingImgPath:string="assets/giphy.gif";
  pageLoaded:boolean=false;
  ngOnInit() {
    this._getFeaturedmovies.getNewReleaseMovies()
      .then(res=>{
        this.movies = res as movie[];
        this.total=this.movies.length;
      this.selectedMovies = this.movies.slice(0,8);
      this.pageLoaded=true;
      })
      .catch(err=>{
      if(err.status===0){
        alert('Server not responding.');
      }
      else if(err.status===400 && err.error.Message) alert(err.error.Message);
      else  alert(err.message);
      });
  }
  prevPage(){
    this.pageNo--;
    this.selectedMovies = this.movies.slice(((this.pageNo)-1)*8,8*this.pageNo);
  }
  nextPage(){
    this.pageNo++;
    this.selectedMovies = this.movies.slice(((this.pageNo)-1)*8,8*this.pageNo);
  }

}
