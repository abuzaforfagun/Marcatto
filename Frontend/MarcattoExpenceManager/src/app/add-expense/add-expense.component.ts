import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  paymentOptions = [];
  constructor() { }

  ngOnInit() {
    this.paymentOptions.push({ id: 1, name: 'Efectivo' });
    this.paymentOptions.push({ id: 2, name: 'Tarjeta' });
    this.paymentOptions.push({ id: 3, name: 'Deposito' });
    this.paymentOptions.push({ id: 4, name: 'Transferencia' });
  }

}
