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
import {FormsModule} from '@angular/forms';
@NgModule({
  declarations: [
    AppComponent,
    RequestsComponent,
    MessagesComponent,
    RequestInfoComponent,
    RequestHeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [TnklfeRequestService],
  bootstrap: [AppComponent]
})
export class AppModule { }
