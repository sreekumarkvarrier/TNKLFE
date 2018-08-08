import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {TnklfeRequestService} from './tnklfe-request.service';
import { AppComponent } from './app.component';
import { RequestsComponent } from './requests/requests.component';
import { HttpClientModule } from '@angular/common/http';
import { MessagesComponent } from './messages/messages.component';
import { AppRoutingModule } from './/app-routing.module';
import { RequestInfoComponent } from './request-info/request-info.component';
import { RequestHeaderComponent } from './request-header/request-header.component';  
import {LoginComponent} from './login/login.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { AppMasterComponent } from './layouts/app-master/app-master.component';
import { AppHeaderComponent } from './layouts/app-header/app-header.component';
@NgModule({
  declarations: [
    AppComponent,
    RequestsComponent,
    MessagesComponent,
    RequestInfoComponent,
    RequestHeaderComponent,
    LoginComponent,
    AppMasterComponent,
    AppHeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [TnklfeRequestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
