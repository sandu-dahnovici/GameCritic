import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PagedResult } from '../models/pagination/paged-result.model';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';
import { Publisher } from '../models/publisher/publisher';
import { PublisherList } from '../models/publisher/publisher-list';
import { UpdatePublisher } from '../models/publisher/update-publisher';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  private url = environment.apiUrl + 'publishers/';

  public search = {
    redirected: false,
    text: '',
  };

  constructor(private http: HttpClient,
    private errorHandling: ErrorHandlingService) { }

  getPublishersPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<PublisherList>> {
    return this.http.post<PagedResult<PublisherList>>(this.url + 'paginated-search', paginatedRequest)
      .pipe(catchError(this.errorHandling.handleError<PagedResult<PublisherList>>()));
  }

  getAllPublishers(): Observable<PublisherList[]> {
    return this.http.get<PublisherList[]>(this.url)
      .pipe(catchError(this.errorHandling.handleError<PublisherList[]>()));
  }

  deletePublisher(id: number): Observable<any> {
    return this.http.delete<any>(this.url + id)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  getPublisherById(id: string): Observable<Publisher> {
    return this.http.get<Publisher>(this.url + `${id}`)
      .pipe(catchError(this.errorHandling.handleError<Publisher>()));
  }

  private createPublisher(publisher: UpdatePublisher): Observable<any> {
    return this.http.post<any>(this.url, publisher)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  private updatePublisher(publisher: UpdatePublisher): Observable<any> {
    return this.http.put<any>(this.url + publisher.id, publisher)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  savePublisher(publisher: UpdatePublisher): Observable<Publisher> {
    if (publisher.id !== undefined && publisher.id > 0) {
      return this.updatePublisher(publisher);
    }
    return this.createPublisher(publisher);
  }
}
