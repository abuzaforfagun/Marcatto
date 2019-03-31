import { Bank } from './../models/bank';
import { HttpService } from './http.service';
import { Injectable } from '@angular/core';
import { API } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankService {

  banks: Bank[];
  isDataLoaded = false;
  constructor(private httpService: HttpService) { }

  getAll(): void {
    this.httpService.get(API.bank.getAll, {}).subscribe(data => {
      this.banks = data;
      this.isDataLoaded = true;
    });
  }

  add(bank: Bank): void {
    this.httpService.post(API.bank.add, bank).subscribe((newAddedBank: Bank) => {
      this.banks.push(newAddedBank);
    });
  }

  terminate(bank: Bank): void {
    this.httpService.put(API.bank.terminate, bank).subscribe(() => {
      this.banks = this.banks.filter(b => b.id !== bank.id, 1);
    });
  }
}
