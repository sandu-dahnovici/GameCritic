import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Award } from 'src/app/models/award/award';
import { GameList } from 'src/app/models/game/game-list';

@Component({
  selector: 'app-award-page',
  templateUrl: './award-page.component.html',
  styleUrls: ['./award-page.component.css']
})
export class AwardPageComponent implements OnInit {

  award: Award;
  games: GameList[] = [];
  ranks: number[] = [];

  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ award }) => {
      this.award = award;
      for (let ranking of award.games) {
        this.games.push(ranking.game);
        this.ranks.push(ranking.rank);
      }
    });
  }

}
