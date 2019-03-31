import { DeleteDialogComponent } from './../delete-dialog/delete-dialog.component';
import { Bank } from './../models/bank';
import { BankService } from './../services/bank.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-bank-accounts',
  templateUrl: './bank-accounts.component.html',
  styleUrls: ['./bank-accounts.component.scss']
})
export class BankAccountsComponent implements OnInit {

  bank: Bank;
  bankName: string;
  accountNumber: string;
  constructor(private router: Router,
    public bankService: BankService,
    public dialog: MatDialog) { }

  ngOnInit() {
    this.bankService.getAll();
    this.bank = new Bank();
  }

  addBank() {
    this.bankService.add(this.bank);
  }


  btnBackClick() {
    this.router.navigateByUrl('dashbaord');
  }

  terminateBank(bank: Bank): void {
    const dialogRef = this.dialog.open(DeleteDialogComponent, {
      width: '250px',
      data: 'Are you sure to delte this bank?'
    });

    dialogRef.afterClosed().subscribe((data) => {
      if (data) {
        this.bankService.terminate(bank);
      }
    });
  }
}
