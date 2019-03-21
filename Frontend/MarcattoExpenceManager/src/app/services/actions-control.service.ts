import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ActionsControlService {

  isAddFormOpen: boolean;
  constructor() {
    this.isAddFormOpen = false;
  }
}
