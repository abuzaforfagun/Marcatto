import { PaymentOptionsService } from './../services/payment-options.service';
import { BankService } from './../services/bank.service';
import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit, Input } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { FormControl } from '@angular/forms';
import { CASH_PAYMENT_ID } from '../configuration/constants';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  bankAccounts = [];
  hideShowAnimator = true;
  date = new FormControl(new Date());
  isBankAccountSelected = false;
  constructor(private actionControlService: ActionsControlService,
    public bankService: BankService,
    public paymentOptionService: PaymentOptionsService) { }

  ngOnInit() {
    this.paymentOptionService.getPaymentOptions();
    this.bankService.getAll();
  }

  addExpense() {
    this.actionControlService.isAddFormOpen = false;
  }

  changePaymentOptions(selectedPaymentOption) {
    if (selectedPaymentOption !== CASH_PAYMENT_ID) {
      this.isBankAccountSelected = true;
    } else {
      this.isBankAccountSelected = false;
    }
  }
}
