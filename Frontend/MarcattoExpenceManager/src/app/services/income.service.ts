import { HttpService } from './http.service';
import { Injectable } from '@angular/core';
import { API } from 'src/environments/environment';
import { Transaction } from '../models/transaction';
import { Dashboard } from '../models/dashboard';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IncomeService {

  income: Dashboard;
  constructor(private httpService: HttpService) { }

  getAll(): Observable<any> {
    return this.httpService.get(API.income.getAll, '');
  }
}
