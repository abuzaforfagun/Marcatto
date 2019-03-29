import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-bank-accounts',
  templateUrl: './bank-accounts.component.html',
  styleUrls: ['./bank-accounts.component.scss']
})
export class BankAccountsComponent implements OnInit {

  bankName: string;
  accountNumber: string;
  constructor(private router: Router) { }

  ngOnInit() {
  }

  btnBackClick() {
    this.router.navigateByUrl("dashbaord");
  }
}
