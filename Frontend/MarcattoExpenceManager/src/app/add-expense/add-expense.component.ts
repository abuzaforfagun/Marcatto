import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit, Input } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  paymentOptions = [];
  bankAccounts = [];
  hideShowAnimator: boolean = true;
  date = new FormControl(new Date());
  isBankAccountSelected = false;
  constructor(private actionControlService: ActionsControlService) { }

  ngOnInit() {
    this.paymentOptions.push({ id: 1, name: 'Efectivo' });
    this.paymentOptions.push({ id: 2, name: 'Tarjeta' });
    this.paymentOptions.push({ id: 3, name: 'Deposito' });
    this.paymentOptions.push({ id: 4, name: 'Transferencia' });
    this.bankAccounts.push({ id: 1, name: 'Bank 1' });
    this.bankAccounts.push({ id: 2, name: 'Bank 2' });
  }

  addExpense() {
    this.actionControlService.isAddFormOpen = false;
  }

  changePaymentOptions(selectedPaymentOption) {
    if (selectedPaymentOption !== 1) {
      this.isBankAccountSelected = true;
    } else {
      this.isBankAccountSelected = false;
    }
  }
}
