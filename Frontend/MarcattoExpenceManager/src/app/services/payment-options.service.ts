import { API } from 'src/environments/environment';
import { PaymentOption } from './../models/payment-option';
import { Injectable } from '@angular/core';
import { HttpService } from './http.service';

@Injectable({
  providedIn: 'root'
})
export class PaymentOptionsService {

  paymentOptions: PaymentOption[];
  constructor(private httpService: HttpService) { }

  getPaymentOptions(): void {
    this.httpService.get(API.paymentOpiton.getAll, {}).subscribe(data => {
      this.paymentOptions = data;
    });
  }
}
