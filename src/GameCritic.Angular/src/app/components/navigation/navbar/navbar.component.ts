import { Component, OnInit } from '@angular/core';
import { GenreList } from 'src/app/models/genre/genre-list';
import { GenreService } from 'src/app/services/genre.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  genres: GenreList[] = [];
  constructor(private genreService : GenreService) { }

  ngOnInit(): void {
    this.genreService.getAllGenres().subscribe((list) => {
      this.genres = list;
    });
  }

}
