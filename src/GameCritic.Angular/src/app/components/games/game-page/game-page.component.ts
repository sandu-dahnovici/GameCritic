import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Game } from 'src/app/models/game/game';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {
  game!: Game;
  panelOpenState = false;

  constructor(private gameService: GameService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ game }) => {
      this.game = game;
    });
    console.log(this.game);
  }

  getImageUrl() {
    return this.gameService.getGameImageUrl(this.game.imageName);
  }

}
