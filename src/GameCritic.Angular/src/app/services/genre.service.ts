import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Genre } from '../models/genre/genre';
import { GenreList } from '../models/genre/genre-list';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  private url = environment.apiUrl + 'genres/';

  constructor(private http: HttpClient,
    private errorHandling: ErrorHandlingService) { }

  getAllGenres(): Observable<GenreList[]> {
    return this.http.get<GenreList[]>(this.url)
      .pipe(catchError(this.errorHandling.handleError<GenreList[]>()));
  }

  getGenreById(id : string): Observable<Genre> {
    return this.http.get<Genre>(this.url + `${id}` + '/games')
      .pipe(catchError(this.errorHandling.handleError<Genre>()));
  }
}
