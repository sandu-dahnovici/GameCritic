import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Game } from '../models/game/game';
import { GameList } from '../models/game/game-list';
import { PagedResult } from '../models/pagination/paged-result.model';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private url = environment.apiUrl + 'games/';

  public search = {
    redirected: false,
    text: '',
  };

  constructor(private http: HttpClient) { }

  getGamesPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<GameList>> {
    return this.http.post<PagedResult<GameList>>(this.url + 'paginated-search', paginatedRequest);
  }

  getGameImageUrl(imageName: string | undefined): string {
    return environment.apiUrl + `blob/${imageName}`;
  }

  getGameById(id: string): Observable<Game> {
    return this.http.get<Game>(this.url + `${id}`);
  }
}
