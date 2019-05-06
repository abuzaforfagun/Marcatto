import { AddTransaction } from './../models/add-transaction';
import { PaymentOptionsService } from './../services/payment-options.service';
import { BankService } from './../services/bank.service';
import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CASH_PAYMENT_ID } from '../configuration/constants';
import * as moment from 'moment';
import { TransactionService } from '../services/transaction.service';

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
  transaction: AddTransaction;
  @Input() isIncomeTransaction: boolean;
  constructor(private actionControlService: ActionsControlService,
    public bankService: BankService,
    public paymentOptionService: PaymentOptionsService,
    private transactionService: TransactionService) { }

  ngOnInit() {
    this.paymentOptionService.getPaymentOptions();
    this.bankService.getAll();

    this.transaction = new AddTransaction();
  }

  addExpense() {
    this.transaction.date = moment(new Date(this.date.value)).format('MM-DD-YYYY');

    this.transactionService.addTransaction(this.isIncomeTransaction, this.transaction).subscribe(data => {
      console.log(data);
    });
  }

  changePaymentOptions(selectedPaymentOption) {
    if (selectedPaymentOption !== CASH_PAYMENT_ID) {
      this.isBankAccountSelected = true;
    } else {
      this.isBankAccountSelected = false;
    }
  }
}
