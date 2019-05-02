import { DashboardService } from './../services/dashboard.service';
import { Transaction } from './../models/transaction';
import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardSummery } from '../models/dashboard-summery';
import * as moment from 'moment';


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
  summery: DashboardSummery;
  currentShortDate = moment(new Date()).format('MMMM YYYY');
  currentFullDate = moment(new Date()).format('MMMM DD, YYYY hh:mm A');

  constructor(public actionControlService: ActionsControlService,
    private dashboardService: DashboardService,
    private router: Router) { }


  /** Gets the total cost of all transactions. */
  getTotalCost() {
    // return this.transactionsData.map(t => t.efevo).reduce((acc, value) => acc + value, 0);
  }

  ngOnInit() {
    this.currentShortDate = this.getCurrentDate(false);
    this.dashboardService.getSummery().subscribe(data => {
      this.summery = data;
    });

    setInterval(() => {
      this.currentFullDate = moment(new Date()).format('MMMM DD, YYYY hh:mm A');
    }, 60000);
  }

  openAddform() {
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
}
