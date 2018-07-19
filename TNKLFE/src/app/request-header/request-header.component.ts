import { Component, OnInit,Input } from '@angular/core';
import { TnkLfeRequest } from '../TnkLfeRequest';


@Component({
  selector: 'app-request-header',
  templateUrl: './request-header.component.html',
  styleUrls: ['./request-header.component.css']
})
export class RequestHeaderComponent implements OnInit {
  @Input() request: TnkLfeRequest;

  constructor()
  {
     
  }

  ngOnInit() 
  {

  }
 
}
