import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Game } from '../models/game/game';
import { GameList } from '../models/game/game-list';
import { UpdateGame } from '../models/game/update-game';
import { PagedResult } from '../models/pagination/paged-result.model';
import { PaginatedRequest } from '../models/pagination/paginated-result.model';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {
  private url = environment.apiUrl + 'games/';

  public search = {
    redirected: false,
    text: '',
  };

  constructor(private http: HttpClient,
    private errorHandling: ErrorHandlingService,) { }

  getGamesPaged(paginatedRequest: PaginatedRequest): Observable<PagedResult<GameList>> {
    return this.http.post<PagedResult<GameList>>(this.url + 'paginated-search', paginatedRequest)
      .pipe(catchError(this.errorHandling.handleError<PagedResult<GameList>>()));
  }

  getGameImageUrl(imageName: string | undefined): string {
    return environment.apiUrl + `blob/${imageName}`;
  }

  getGameById(id: string): Observable<Game> {
    return this.http.get<Game>(this.url + `${id}`)
      .pipe(catchError(this.errorHandling.handleError<Game>()));
  }

  deleteGame(id: number): Observable<any> {
    return this.http.delete<any>(this.url + id)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  private createGame(game: UpdateGame): Observable<Game> {
    return this.http.post<Game>(this.url, game)
      .pipe(catchError(this.errorHandling.handleError<Game>()));
  }

  private updateGame(game: UpdateGame): Observable<any> {
    return this.http.put<any>(this.url + game.id, game)
      .pipe(catchError(this.errorHandling.handleError<any>()));
  }

  saveGame(game: UpdateGame): Observable<Game> {
    if (game.id !== undefined && game.id > 0) {
      return this.updateGame(game);
    }
    return this.createGame(game);
  }

  setGameImage(id: number, file: File): Observable<string> {
    const url = `${this.url}${id}/image`;
    const options = {
      headers: new HttpHeaders({
        'Content-Disposition': 'multipart/form-data',
      }),
      responseType: 'text',
    };
    const formData = new FormData();
    formData.append('image', file, file.name);
    // @ts-ignore
    return this.http.patch<string>(url, formData, options)
      .pipe(catchError(this.errorHandling.handleError<string>()));
  }

}
