import { MoviesService } from 'src/app/services/movies.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-search',
  templateUrl: './movie-search.component.html',
  styleUrls: ['./movie-search.component.css']
})
export class MovieSearchComponent implements OnInit {

  searchedMovies:any;
  constructor(private _route:ActivatedRoute, private _getMovies:MoviesService) { }

  ngOnInit(): void {
    this._route.paramMap.subscribe(async para=>{
      let name = para.get('name');
      this._getMovies.getSearchMovies(name as string)
        .then(res=>{
          this.searchedMovies=res;
        })
        .catch(err=>{
          if(err.status===0){
            alert('Server not responding.');
          }
          else if(err.status===400 && err.error.Message) alert(err.error.Message);
          else  alert(err.message);
        });
    });
  }

}
