import { Transaction } from './../models/transaction';
import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { Router } from '@angular/router';
import { IncomeService } from '../services/income.service';
import { Dashboard } from '../models/dashboard';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  hideShowAnimator = true;
  isAddOpen = false;
  displayedColumns: string[] = ['date', 'description', 'efevo', 'banco'];
  columnsToDisplay: string[] = this.displayedColumns.slice();
  transitions: Transaction[];

  constructor(public actionControlService: ActionsControlService,
    private router: Router) { }


  /** Gets the total cost of all transactions. */
  getTotalCost() {
    // return this.transactionsData.map(t => t.efevo).reduce((acc, value) => acc + value, 0);
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
