import { AddTransaction } from './../models/add-transaction';
import { PaymentOptionsService } from './../services/payment-options.service';
import { BankService } from './../services/bank.service';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CASH_PAYMENT_ID } from '../configuration/constants';
import * as moment from 'moment';
import { TransactionService } from '../services/transaction.service';
import { Subject } from 'rxjs';
import { Transaction } from '../models/transaction';

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
  errors = '';

  @Input() transactionType: string;
  @Input() clearForm: Subject<any>;
  @Output() addDataToTable = new EventEmitter<Transaction>();
  @Output() closeForm = new EventEmitter<boolean>();
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
    if (this.checkInputs()) {
      this.transactionService.addTransaction(this.transactionType, this.transaction).subscribe(data => {
        this.transaction = new AddTransaction();
        this.addDataToTable.next(data);
      });
    }
  }

  changePaymentOptions(selectedPaymentOption) {
    if (selectedPaymentOption !== CASH_PAYMENT_ID) {
      this.isBankAccountSelected = true;
    } else {
      this.isBankAccountSelected = false;
    }
  }

  checkInputs(): boolean {
    let isInputValid = true;
    this.errors = '';
    if (!this.transaction.description) {
      this.errors += 'Please enter description.<br/>';
      isInputValid = false;
    }
    if (!this.transaction.amount) {
      this.errors += 'Please enter amount.<br/>';
      isInputValid = false;
    }
    if (!this.transaction.paymentOptionId) {
      this.errors += 'Please select payment option.<br/>';
      isInputValid = false;
    } else if (this.transaction.paymentOptionId !== 1 && !this.transaction.bankAccountId) {
      this.errors += 'Please select bank account number;';
      isInputValid = false;
    }
    return isInputValid;
  }

  clickCloseForm(): void {
    this.closeForm.next(true);
  }
}
