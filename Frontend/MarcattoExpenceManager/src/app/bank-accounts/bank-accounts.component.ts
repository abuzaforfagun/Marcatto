import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bank-accounts',
  templateUrl: './bank-accounts.component.html',
  styleUrls: ['./bank-accounts.component.scss']
})
export class BankAccountsComponent implements OnInit {

  bankName: string;
  accountNumber: string;
  constructor() { }

  ngOnInit() {
  }

}
