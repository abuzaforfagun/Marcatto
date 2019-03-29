import { BankAccountsComponent } from './bank-accounts/bank-accounts.component';
import { LoginComponent } from './login/login.component';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: 'dashbaord', component: DashboardComponent },
  { path: 'expense/add', component: AddExpenseComponent },
  { path: 'login', component: LoginComponent },
  { path: 'banks', component: BankAccountsComponent },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
