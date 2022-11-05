import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PagedResult } from '../models/pagination/paged-result.model';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';
import { PublisherList } from '../models/publisher/publisher-list';

@Injectable({
  providedIn: 'root'
})
export class PublisherService {

  private url = environment.apiUrl + 'publishers/';

  public search = {
    redirected: false,
    text: '',
  };

  constructor(private http: HttpClient) { }

  getPublishersPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<PublisherList>> {
    return this.http.post<PagedResult<PublisherList>>(this.url + 'paginated-search', paginatedRequest);
  }

  getAllPublishers(): Observable<PublisherList[]> {
    return this.http.get<PublisherList[]>(this.url);
  }

  deletePublisher(id: number): Observable<any> {
    return this.http.delete<any>(this.url + id);
  }

}
