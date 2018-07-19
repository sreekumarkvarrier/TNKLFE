import { NgModule }             from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RequestsComponent } from './requests/requests.component';
import { RequestInfoComponent } from './request-info/request-info.component';


const routes : Routes= 
[
{path:'requestList',component:RequestsComponent},
{path:'request/:id',component:RequestInfoComponent},
{path:'',redirectTo:'/requestList',pathMatch:'full'}

]

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})


export class AppRoutingModule { }
