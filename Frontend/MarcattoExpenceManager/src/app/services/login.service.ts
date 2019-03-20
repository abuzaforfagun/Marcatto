import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  isLoggedIn = false;
  token: string;
  constructor() {
    this.isLoggedIn = localStorage.getItem('token') ? true : false;
  }

  loginUser() {
    this.isLoggedIn = true;
    this.token = 'something';
    localStorage.setItem('token', this.token);
  }
}
