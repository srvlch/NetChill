import { movie } from './../../models/movies';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-movie-render',
  templateUrl: './movie-render.component.html',
  styleUrls: ['./movie-render.component.css']
})
export class MovieRenderComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  @Input('movies') movies:movie[]=[];

  @Input('column-direction') colDir:boolean=false;

  @Input('clickable') clickable:boolean=true;

}
