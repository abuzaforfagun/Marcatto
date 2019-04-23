import { Transaction } from './../dashboard.component';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-expense-table',
  templateUrl: './expense-table.component.html',
  styleUrls: ['./expense-table.component.scss']
})
export class ExpenseTableComponent implements OnInit {

  @Input() transactions: Transaction[];
  displayedColumns: string[] = ['date', 'description', 'efevo', 'banco'];
  @Input() tableType: string;

  constructor() { }

  ngOnInit() {
    console.log(this.transactions)
  }

  getTotalCost() {
    return this.transactions.map(t => t.efevo).reduce((acc, value) => acc + value, 0);
  }

}
