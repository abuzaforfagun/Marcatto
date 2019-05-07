import { AddTransaction } from './../models/add-transaction';
import { HttpService } from './http.service';
import { Injectable } from '@angular/core';
import { API } from 'src/environments/environment';
import { Transaction } from '../models/transaction';
import { Dashboard } from '../models/dashboard';
import { Observable } from 'rxjs';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  income: Dashboard;
  constructor(private httpService: HttpService) { }

  getAllIncomeTransactions(): Observable<any> {
    return this.httpService.get(API.income.getAll, '');
  }

  getCurrentIncomeTransactions(): Observable<any> {
    const date = moment(new Date()).format('MM-DD-YYYY');
    return this.httpService.get(API.income.getByDate + date, '');
  }

  getAllExpenseTransactions(): Observable<any> {
    return this.httpService.get(API.expense.getAll, '');
  }

  getCurrentExpenseTransactions(): Observable<any> {
    const date = moment(new Date()).format('MM-DD-YYYY');
    return this.httpService.get(API.expense.getByDate + date, '');
  }

  addTransaction(transactionType: string, data: AddTransaction): Observable<any> {
    const url = transactionType === 'Income' ? API.income.add : API.expense.add;
    return this.httpService.post(url, data);
  }
}
