import { transition } from '@angular/animations';
import { Dashboard } from './../../models/dashboard';
import { Component, OnInit, Input } from '@angular/core';
import { IncomeService } from 'src/app/services/income.service';
import { Transaction } from 'src/app/models/transaction';

@Component({
  selector: 'app-income-table',
  templateUrl: './income-table.component.html',
  styleUrls: ['./income-table.component.scss']
})
export class IncomeTableComponent implements OnInit {

  @Input() tableType: string;
  displayedColumns = ['date', 'description', 'cashPayment', 'bank', 'bankName'];
  columnsToDisplay = ['Date', 'Description', 'Cash Payment', 'Bank', 'Bank Name',];
  transactions: Transaction[];
  constructor(private incomeService: IncomeService) { }

  ngOnInit() {
    if (this.tableType === 'income') {
      this.incomeService.getAllIncomeTransactions().subscribe((data: Dashboard) => {
        this.transactions = data.transactions;
      });
    } else {
      this.incomeService.getAllExpenseTransactions().subscribe((data: Dashboard) => {
        this.transactions = data.transactions;
      });
    }

  }

  getBankTransactions(): number {
    return this.transactions.filter(t => t.bankId > 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);

  }

  getTotalCashTransactions(): number {
    return this.transactions.filter(t => t.bankId === 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }

  checkCashPayment(amount: number, bankId: number): string {
    if (bankId === 0) {
      return amount.toString();
    }
    return '';
  }

  getTotalTransactions(): number {
    return this.transactions.map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }

  getBankAmount(amount: number, bankId: number): string {
    if (bankId > 0) {
      return amount.toString();
    }
    return '';
  }
}
