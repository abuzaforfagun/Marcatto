import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  email = '';
  password = '';
  constructor(private router: Router,
    private loginService: LoginService) { }

  ngOnInit() {
  }

  login() {
    this.loginService.loginUser();
    this.router.navigateByUrl('expense/add');
  }

}
