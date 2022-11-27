import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UpdateRanking } from '../models/ranking/update-ranking';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class RankingService {

  private url = environment.apiUrl + 'rankings/';

  constructor(private http: HttpClient,
    private errorHandling: ErrorHandlingService) { }

  getAvailableRanksByAwardId(id: number): Observable<number[]> {
    return this.http.get<number[]>(this.url + `available/${id}`)
      .pipe(catchError(this.errorHandling.handleError<number[]>()));
  }

  public createRanking(ranking: UpdateRanking): Observable<any> {
    return this.http.post<any>(this.url, ranking)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  deleteRanking(id: number): Observable<any> {
    return this.http.delete<any>(this.url + id)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }
}
