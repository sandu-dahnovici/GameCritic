import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  @Output() onSearch: EventEmitter<string> = new EventEmitter();
  text: string;

  constructor(private gameService: GameService, private router: Router) { }

  ngOnInit(): void {
  }

  search() {
    this.onSearch.emit(this.text);
  }
}
