import { AddTransaction } from './../models/add-transaction';
import { PaymentOptionsService } from './../services/payment-options.service';
import { BankService } from './../services/bank.service';
import { Component, OnInit, Input } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CASH_PAYMENT_ID } from '../configuration/constants';
import * as moment from 'moment';
import { TransactionService } from '../services/transaction.service';
import { Subject } from 'rxjs';

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

  @Input() transactionType: string;
  @Input() clearForm: Subject<any>;
  constructor(
    public bankService: BankService,
    public paymentOptionService: PaymentOptionsService,
    private transactionService: TransactionService) { }

  ngOnInit() {
    this.paymentOptionService.getPaymentOptions();
    this.bankService.getAll();

    this.transaction = new AddTransaction();

    this.clearForm.subscribe(() => {
      this.transaction = new AddTransaction();
    });
  }

  addExpense() {
    this.transaction.date = moment(new Date(this.date.value)).format('MM-DD-YYYY');

    this.transactionService.addTransaction(this.transactionType, this.transaction).subscribe(data => {
      this.transaction = new AddTransaction();
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
