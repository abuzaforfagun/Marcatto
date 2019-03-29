import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { Router } from '@angular/router';





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
  hideShowAnimator: boolean = true;

  constructor(public actionControlService: ActionsControlService,
    private router: Router) { }
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

  ngOnInit() {
  }

  openAddform() {
    this.actionControlService.isAddFormOpen = true;
  }

  manageBanks() {
    this.router.navigateByUrl('banks');
  }

}
