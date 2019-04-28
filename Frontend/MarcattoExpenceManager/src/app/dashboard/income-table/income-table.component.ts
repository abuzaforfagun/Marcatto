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
  displayedColumns = ["date", "description", "amount", "bankName", "cashPayment"];
  columnsToDisplay = ["Date", "Description", "Amount", "Bank Name", "Cash Payment"];
  transactions: Transaction[];
  constructor(private incomeService: IncomeService) { }

  ngOnInit() {
    this.incomeService.getAll().subscribe((data: Dashboard) => {
      console.log(data);
      // this.columnsToDisplay = data.availableColumns;
      // this.displayedColumns = data.availableColumns;
      this.transactions = data.transactions;
    });
  }

  getBankTransactions(): number {
    return this.transactions.filter(t => t.bankId > 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);

  }

  getTotalCashTransactions(): number {
    return this.transactions.filter(t => t.bankId == 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }

  checkCashPayment(isCashPayment: bollean): string {
    if (isCashPayment) {
      return "Yes";
    }
    return "";
  }

  getTotalTransactions(): number {
    return this.transactions.map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }
}
