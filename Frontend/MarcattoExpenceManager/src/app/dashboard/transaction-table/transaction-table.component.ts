import { Component, OnInit, Input } from '@angular/core';
import { Transaction } from 'src/app/models/transaction';

@Component({
  selector: 'app-transaction-table',
  templateUrl: './transaction-table.component.html',
  styleUrls: ['./transaction-table.component.scss']
})
export class TransactionTableComponent implements OnInit {

  @Input() tableType: string;
  @Input() tableData: Transaction[];
  displayedColumns = ['date', 'description', 'cashPayment', 'bank', 'bankName'];
  columnsToDisplay = ['Date', 'Description', 'Cash Payment', 'Bank', 'Bank Name',];
  constructor() { }

  ngOnInit() {
  }

  getBankTransactions(): number {
    return this.tableData.filter(t => t.bankId > 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);

  }

  getTotalCashTransactions(): number {
    return this.tableData.filter(t => t.bankId === 0).map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }

  checkCashPayment(amount: number, bankId: number): string {
    if (bankId === 0) {
      return amount.toString();
    }
    return '';
  }

  getTotalTransactions(): number {
    return this.tableData.map(t => t.amount).reduce((acc, value) => acc + value, 0);
  }

  getBankAmount(amount: number, bankId: number): string {
    if (bankId > 0) {
      return amount.toString();
    }
    return '';
  }

  // TODO: improve the method
  addDataToTable(data: Transaction) {
    const tableData = this.tableData;
    this.tableData = [];
    tableData.push(data);
    tableData.forEach(val => {
      this.tableData.push(val);
    });
  }
}
