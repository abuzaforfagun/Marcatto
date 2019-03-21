import { ActionsControlService } from './../services/actions-control.service';
import { Component, OnInit, Input } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';

@Component({
  selector: 'app-add-expense',
  templateUrl: './add-expense.component.html',
  styleUrls: ['./add-expense.component.scss']
})
export class AddExpenseComponent implements OnInit {

  paymentOptions = [];
  hideShowAnimator: boolean = true;
  constructor(private actionControlService: ActionsControlService) { }

  ngOnInit() {
    this.paymentOptions.push({ id: 1, name: 'Efectivo' });
    this.paymentOptions.push({ id: 2, name: 'Tarjeta' });
    this.paymentOptions.push({ id: 3, name: 'Deposito' });
    this.paymentOptions.push({ id: 4, name: 'Transferencia' });
  }

  addExpense() {
    this.actionControlService.isAddFormOpen = false;
  }
}
