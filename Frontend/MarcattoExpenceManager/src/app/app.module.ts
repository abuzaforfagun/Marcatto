import { PaymentOptionsService } from './services/payment-options.service';
import { ActionsControlService } from './services/actions-control.service';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgModule } from '@angular/core';
import {
  MatFormFieldModule, MatInputModule, MatNativeDateModule, MatIconModule, MatSelectModule,
  MatOptionModule, MatTableModule, MatDialogModule
} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AddExpenseComponent } from './add-expense/add-expense.component';
import { FormsModule } from '@angular/forms';
import { LoginService } from './services/login.service';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BankAccountsComponent } from './bank-accounts/bank-accounts.component';
import { HttpClientModule } from '@angular/common/http';
import { DeleteDialogComponent } from './delete-dialog/delete-dialog.component';
import { ExpenseTableComponent } from './dashboard/expense-table/expense-table.component';
import { IncomeTableComponent } from './dashboard/income-table/income-table.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddExpenseComponent,
    DashboardComponent,
    BankAccountsComponent,
    DeleteDialogComponent,
    ExpenseTableComponent,
    IncomeTableComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatSelectModule,
    MatOptionModule,
    MatTableModule,
    MatDialogModule
  ],
  providers: [
    LoginService,
    ActionsControlService,
    PaymentOptionsService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    DeleteDialogComponent
  ]
})
export class AppModule { }
