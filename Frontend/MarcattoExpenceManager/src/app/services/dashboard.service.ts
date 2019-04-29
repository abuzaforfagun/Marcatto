import { API } from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {

  constructor(private httpService: HttpService) { }

  getSummery(): Observable<any> {
    return this.httpService.get(API.dashboard.summery, '');
  }
}
