import { TransactionTableComponent } from './transaction-table/transaction-table.component';
import { DashboardService } from './../services/dashboard.service';
import { Transaction } from './../models/transaction';
import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit, ViewChild, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardSummery } from '../models/dashboard-summery';
import * as moment from 'moment';
import { Subject } from 'rxjs';
import { TransactionService } from '../services/transaction.service';
import { Dashboard } from '../models/dashboard';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  hideShowAnimator = true;
  isAddOpen = false;
  summery: DashboardSummery;
  currentFullDate = moment(new Date()).format('MMMM DD, YYYY hh:mm A');
  balanceCash: number;
  balanceBank: number;
  transactionType: string;
  clearAddTransactionForm: Subject<any>;

  incomes: Transaction[];
  expenses: Transaction[];

  @ViewChild('income') incomeTable: TransactionTableComponent;
  @ViewChild('expense') expenseTable: TransactionTableComponent;

  constructor(public actionControlService: ActionsControlService,
    private transactionService: TransactionService,
    private dashboardService: DashboardService,
    private router: Router) { }

  ngOnInit() {
    this.clearAddTransactionForm = new Subject();
    this.GetDashBoardSummery();

    setInterval(() => {
      this.currentFullDate = moment(new Date()).format('MMMM DD, YYYY hh:mm A');
    }, 60000);

    this.transactionService.getCurrentIncomeTransactions().subscribe((data: Dashboard) => {
      this.incomes = data.transactions;
    });
    this.transactionService.getCurrentExpenseTransactions().subscribe((data: Dashboard) => {
      this.expenses = data.transactions;
    });
  }

  private GetDashBoardSummery() {
    this.dashboardService.getSummery().subscribe((data: DashboardSummery) => {
      this.summery = data;
      this.balanceCash = data.cashBalance;
      this.balanceBank = data.bankBalance;
    });
  }

  openAddform(isIncomeTransaction: boolean) {
    this.clearAddTransactionForm.next(true);
    this.transactionType = isIncomeTransaction ? 'Income' : 'Expense';
    this.actionControlService.isAddFormOpen = true;
  }

  manageBanks() {
    this.router.navigateByUrl('banks');
  }

  getCurrentDate(isFullDate: boolean): string {
    const date = new Date();
    const monthDictionary = ['January', 'February', 'March', 'April', 'May', 'June',
      'July', 'Auguest', 'September', 'October', 'November', 'December'];
    const monthNumber = date.getMonth();

    if (!isFullDate) {
      return monthDictionary[monthNumber] + ' ' + date.getFullYear();
    }
    return moment(new Date()).format('MMMM DD, YYYY hh:mm A');
  }

  addDataToTable(transaction: Transaction): void {
    if (this.transactionType === 'Income') {
      this.incomeTable.addDataToTable(transaction);
    } else if (this.transactionType === 'Expense') {
      this.expenseTable.addDataToTable(transaction);
    }
    this.GetDashBoardSummery();
  }

}
