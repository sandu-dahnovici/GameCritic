import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { GenreList } from '../models/genre/genre-list';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  private url = environment.apiUrl + 'genres/';

  constructor(private http: HttpClient) { }

  getAllGenres(): Observable<GenreList[]> {
    return this.http.get<GenreList[]>(this.url);
  }
}
