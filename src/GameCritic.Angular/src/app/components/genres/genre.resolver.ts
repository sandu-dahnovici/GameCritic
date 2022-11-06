import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Genre } from 'src/app/models/genre/genre';
import { GenreService } from 'src/app/services/genre.service';

@Injectable({
  providedIn: 'root'
})
export class GenreResolver implements Resolve<Genre> {
  constructor(private service: GenreService) { }
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Genre> | Promise<Genre> | Genre {
    return this.service.getGenreById(route.paramMap.get('id') as string);
  }
}
