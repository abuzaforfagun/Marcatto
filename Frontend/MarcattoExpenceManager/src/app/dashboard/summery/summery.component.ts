import { Component, OnInit, Input } from '@angular/core';
import { TransactionSummery } from 'src/app/models/transaction-summery';

@Component({
  selector: 'app-summery',
  templateUrl: './summery.component.html',
  styleUrls: ['./summery.component.scss']
})
export class SummeryComponent implements OnInit {

  @Input() summery: TransactionSummery;
  constructor() { }

  ngOnInit() {
  }

}
