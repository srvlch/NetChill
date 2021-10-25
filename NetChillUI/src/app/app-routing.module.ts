import { RecommendedComponent } from './components/dashboard/recommended/recommended.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminAuthGaurdService } from './auth-gaurd/admin-auth-gaurd.service';
import { AuthGuardService } from './auth-gaurd/auth-guard.service';
import { LoginAuthGaurdService } from './auth-gaurd/login-auth-gaurd.service';
import { AnonomousDashboardComponent } from './components/anonomous-dashboard/anonomous-dashboard.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { FeaturedComponent } from './components/dashboard/featured/featured.component';
import { HomeComponent } from './components/dashboard/home/home.component';
import { MylistComponent } from './components/dashboard/mylist/mylist.component';
import { NewreleaseComponent } from './components/dashboard/newrelease/newrelease.component';
import { RevokeSuscriptionComponent } from './components/dashboard/revoke-suscription/revoke-suscription.component';
import { TrendingComponent } from './components/dashboard/trending/trending.component';
import { UpcomingComponent } from './components/dashboard/upcoming/upcoming.component';
import { UploadComponent } from './components/dashboard/upload/upload.component';
import { LoginComponent } from './components/login/login.component';
import { MovieSearchComponent } from './components/movie-search/movie-search.component';
import { MoviedetailsComponent } from './components/moviedetails/moviedetails.component';
import { NotfoundComponent } from './components/notfound/notfound.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';

const routes: Routes = [
  {path:'signup' , component:SignUpComponent, canActivate:[LoginAuthGaurdService] },
  {path:'login' , component:LoginComponent, canActivate:[LoginAuthGaurdService] },
  {
    path:'dashboard' , 
    component:DashboardComponent ,
    canActivate : [AuthGuardService],
    children:[
      {
        path:'' , 
      redirectTo: '/dashboard/(dashboard:home)' ,
      pathMatch:'full' 
      },
      {
        path:'home' ,
        component: HomeComponent , 

        outlet:'dashboard' 
      },
      {
        path:'trending' , 
        component: TrendingComponent , 
        outlet:'dashboard' },
      {
        path:'featured' , 
        component: FeaturedComponent , 
        outlet:'dashboard' },
      {

        path:'newrelease' , 
        component: NewreleaseComponent , 
        outlet:'dashboard' 
      },
      {
        path:'upcoming' , 
        component: UpcomingComponent , 
        outlet:'dashboard' 
      },
      {
        path:'recommended' , 
        component: RecommendedComponent , 
        outlet:'dashboard' 
      },
      {
        path:'mylist' , 
        component: MylistComponent , 
        outlet:'dashboard' 
      },
      {
        path:'revoke' , 
        component: RevokeSuscriptionComponent , 
        outlet:'dashboard', 
        canActivate:[AdminAuthGaurdService]
      },
      {
        path:'upload' , 
        component: UploadComponent , 
        outlet:'dashboard', 
        canActivate:[AdminAuthGaurdService] 
      },
    ] 
  },
  {
    path:'anonomous' , 
    component:AnonomousDashboardComponent, 
    canActivate:[LoginAuthGaurdService]
  },
  {
    path:'' , 
    redirectTo:'dashboard' ,
    pathMatch:'full'
  },
  {
    
    path:'moviedetails/:id' , 
    component:MoviedetailsComponent ,
    canActivate : [AuthGuardService],
  },
  {
    
    path:'moviesearch/:name' , 
    component:MovieSearchComponent ,
    canActivate : [AuthGuardService],
  },
  {
    
    path:'**' , 
    component:NotfoundComponent
  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
