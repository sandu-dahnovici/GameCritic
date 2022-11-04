import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProgressBarService {

  isLoading: boolean = true;

  setLoading(state: boolean): void {
    this.isLoading = state;
  }
}