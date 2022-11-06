import { Component, Input, OnInit } from '@angular/core';
import { GameList } from 'src/app/models/game/game-list';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-games-grid',
  templateUrl: './games-grid.component.html',
  styleUrls: ['./games-grid.component.css']
})
export class GamesGridComponent implements OnInit {

  @Input("games") games: GameList[] = [];

  constructor(private gameService: GameService) { }

  ngOnInit(): void {
  }

  getImageUrl(imageName?: string) {
    if (imageName) {
      return this.gameService.getGameImageUrl(imageName);
    }
    return 'assets/no-image.jpg';
  }

}
