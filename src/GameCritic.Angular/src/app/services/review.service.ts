import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Review } from '../models/review/review';
import { ErrorHandlingService } from './error-handling.service';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';
import { PagedResult } from '../models/pagination/paged-result.model';
import { UpdateReview } from '../models/review/update-review';
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

  getReviewIdByGameAndUserId(gameId: number, userId: number | undefined): Observable<number> {
    return this.http.get<number>(this.url + `games/${gameId}/users/${userId}`)
      .pipe(catchError(this.errorHandling.handleError<number>()));
  }

  getReviewId(id: number): Observable<Review> {
    return this.http.get<Review>(this.url + `${id}`)
      .pipe(catchError(this.errorHandling.handleError<Review>()));
  }


  private createReview(review: UpdateReview): Observable<any> {
    return this.http.post<any>(this.url, review)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  private updateReview(review: UpdateReview): Observable<any> {
    return this.http.put<any>(this.url + review.id, review)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  saveReview(review: UpdateReview): Observable<any> {
    if (review.id !== undefined && review.id > 0) {
      return this.updateReview(review);
    }
    return this.createReview(review);
  }

  deleteReview(id: number): Observable<any> {
    return this.http.delete<any>(this.url + id)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

}
