import { Component, OnInit } from '@angular/core';





export interface Transaction {
  date: string;
  description: string;
  efevo: number;
  banco: number;
}






@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  displayedColumns: string[] = ['date', 'description', 'efevo', 'banco'];
  transactions: Transaction[] = [
    { date: 'Jueves, 14 marzo 2019', description: 'Corte marcato', efevo: 80, banco: 0 },
    { date: 'Jueves, 15 marzo 2019', description: 'Corte marcato', efevo: 0, banco: 120 }
  ];

  isAddOpen = false;

  /** Gets the total cost of all transactions. */
  getTotalCost() {
    return this.transactions.map(t => t.efevo).reduce((acc, value) => acc + value, 0);
  }

  constructor() { }

  ngOnInit() {
  }

  openAddform() {
    this.isAddOpen = true;
  }

}
