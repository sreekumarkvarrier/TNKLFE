import { Component, OnInit } from '@angular/core';
import {TnklfeRequestService} from '../tnklfe-request.service';
import {TnkLfeRequest} from '../TnkLfeRequest';



@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.css']
})
export class RequestsComponent implements OnInit {
  
  //supportRequests:TnkLfeRequest[];
  supportRequests: TnkLfeRequest[]=[];
  
  constructor(private tnklfeRequestService:TnklfeRequestService){}
 
  ngOnInit() 
  {
    this.GetAllRequests();
  }
  
  GetAllRequests()
  {

  this.tnklfeRequestService.GetAllRequests().subscribe(supportRequests => this.supportRequests = supportRequests);
  console.log(this.tnklfeRequestService.GetAllRequests());
  }
 
  
      
  

}
