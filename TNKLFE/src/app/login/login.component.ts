import { OnInit } from '@angular/core';
import { Component, Input, OnChanges }       from '@angular/core';
import { FormArray, FormBuilder, FormGroup, FormControl, Validators  } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { routerNgProbeToken, RouterModule } from '@angular/router/src/router_module';
//import { AuthenticationService, AlertService } from '../_services';
import { first } from 'rxjs/operators';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loading = false;
  submitted = false;
  loginForm = new FormGroup({
    username:new FormControl(),
    password:new FormControl()
 });
  constructor( 
    private router: Router, 
    private formBuilder: FormBuilder,
   // private authenticationService: AuthenticationService,
  //  private alertService: AlertService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
  });
  }
  // convenience getter for easy access to form fields
  get f() { return this.loginForm.controls; }
  onSubmit() {
    this.submitted = true;
     // stop here if form is invalid
     if (this.loginForm.invalid) {
      return;
  }
  //
   this.router.navigate(['/requestList']);

  this.loading = true;
 
  }
}
