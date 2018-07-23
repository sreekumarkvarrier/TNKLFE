import { Component, OnInit } from '@angular/core';
import { TnkLfeRequest } from '../TnkLfeRequest';
import { ActivatedRoute } from '../../../node_modules/@angular/router';
import { TnklfeRequestService } from '../tnklfe-request.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-request-info',
  templateUrl: './request-info.component.html',
  styleUrls: ['./request-info.component.css']
})
export class RequestInfoComponent implements OnInit {
  request: TnkLfeRequest;
  constructor(private route: ActivatedRoute, private requestService: TnklfeRequestService,private location:Location) { }

  ngOnInit() 
  {
    this.getRequest();
  }
  getRequest()
  {
    
    const id = this.route.snapshot.paramMap.get('id');
    console.log("inside getreq in reqInfo"+id);
    this.requestService.GetRequest(parseInt(id))
    .subscribe(request => this.request = request );
  }
  save()
  {
      this.requestService.UpdateRequest(this.request).subscribe(()=>this.goBack())
  }
  goBack(): void {
    this.location.back();
  }
}
