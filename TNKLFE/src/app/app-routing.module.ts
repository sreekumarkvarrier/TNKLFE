import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestsComponent } from './requests/requests.component';
import { RequestInfoComponent } from './request-info/request-info.component';
import {LoginComponent} from './login/login.component';
import {AppMasterComponent} from './layouts/app-master/app-master.component';

const routes : Routes= 
[
  {path:'',redirectTo:'/LoginComponent',pathMatch:'full'},
  {path:'LoginComponent',component:LoginComponent},
      //Site routes goes here 
    { 
      path: '', 
      component: AppMasterComponent,
      children: [
       // { path: '', component: AppHeaderComponent, pathMatch: 'full'},
        { path: 'requestList', component: RequestsComponent },
        { path: 'request/:id', component: RequestInfoComponent }
      ]
  },
// {path:'requestList',component:RequestsComponent},
// {path:'request/:id',component:RequestInfoComponent},
{path:'',redirectTo:'/LoginComponent',pathMatch:'full'}

]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})


export class AppRoutingModule { }
