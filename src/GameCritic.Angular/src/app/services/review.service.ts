import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review/review';
import { ErrorHandlingService } from './error-handling.service';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';
import { PagedResult } from '../models/pagination/paged-result.model';
import { ReviewGame } from '../models/review/review-game';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  private url = environment.apiUrl + 'reviews/';

  constructor(private http: HttpClient,
    private errorHandling: ErrorHandlingService) { }

  getPagedReviewsByGameId(id: number, paginatedRequest: PaginatedRequest): Observable<PagedResult<Review>> {
    return this.http
      .post<PagedResult<Review>>(this.url + 'paginated-search/games/' + `${id}`, paginatedRequest)
      .pipe(catchError(this.errorHandling.handleError<PagedResult<Review>>()));
  }

  getPagedReviewsByUserId(id: number, paginatedRequest: PaginatedRequest): Observable<PagedResult<ReviewGame>> {
    return this.http
      .post<PagedResult<ReviewGame>>(this.url + 'paginated-search/users/' + `${id}`, paginatedRequest)
      .pipe(catchError(this.errorHandling.handleError<PagedResult<ReviewGame>>()));
  }

}
