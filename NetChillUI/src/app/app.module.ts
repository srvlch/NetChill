import { GetmoviedetailsService } from './services/getmoviedetails.service';
import { MoviesService } from './services/movies.service';
import { AdminAuthGaurdService } from './auth-gaurd/admin-auth-gaurd.service';
import { UploadingService } from './services/uploading.service';
import { environment } from './../environments/environment';
import { LoginAuthGaurdService } from './auth-gaurd/login-auth-gaurd.service';
import { RouterModule } from '@angular/router';
import { AuthService } from './services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { AnonomousDashboardComponent } from './components/anonomous-dashboard/anonomous-dashboard.component';
import { AuthGuardService } from './auth-gaurd/auth-guard.service';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/dashboard/home/home.component';
import { FeaturedComponent } from './components/dashboard/featured/featured.component';
import { NewreleaseComponent } from './components/dashboard/newrelease/newrelease.component';
import { UpcomingComponent } from './components/dashboard/upcoming/upcoming.component';
import { MylistComponent } from './components/dashboard/mylist/mylist.component';
import { AngularFireModule } from '@angular/fire';
import { AngularFireStorageModule } from '@angular/fire/storage';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { UploadComponent } from './components/dashboard/upload/upload.component';
import { RevokeSuscriptionComponent } from './components/dashboard/revoke-suscription/revoke-suscription.component';
import { MovieRenderComponent } from './components/movie-render/movie-render.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';
import { CommonModule } from '@angular/common';
import { HomeRenderComponent } from './components/home-render/home-render.component';
import { MovieSearchComponent } from './components/movie-search/movie-search.component';
import { TrendingComponent } from './components/dashboard/trending/trending.component';
import { RecommendedComponent } from './components/dashboard/recommended/recommended.component';
@NgModule({
  declarations: [
    AppComponent,
    SignUpComponent,
    DashboardComponent,
    NotfoundComponent,
    AnonomousDashboardComponent,
    LoginComponent,
    HomeComponent,
    FeaturedComponent,
    NewreleaseComponent,
    UpcomingComponent,
    MylistComponent,
    UploadComponent,
    RevokeSuscriptionComponent,
    MovieRenderComponent,
    MoviedetailsComponent,
    HomeRenderComponent,
    MovieSearchComponent,
    TrendingComponent,
    RecommendedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFireStorageModule,
    AngularFireDatabaseModule,
  ],
  providers: [
    AuthService,
    GetmoviedetailsService,
    AuthGuardService,
    MoviesService,
    LoginAuthGaurdService,
    UploadingService,
    AdminAuthGaurdService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
