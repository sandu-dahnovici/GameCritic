import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { Game } from 'src/app/models/game/game';
import { Review } from 'src/app/models/review/review';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {
  game!: Game;
  panelOpenState = false;
  dataSource = new MatTableDataSource<Review>;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private gameService: GameService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ game }) => {
      this.game = game;
      this.dataSource = new MatTableDataSource<Review>(this.game.reviews);
    });
  }

  getImageUrl(imageName?: string) {
    if (imageName) {
      return this.gameService.getGameImageUrl(imageName);
    }
    return 'assets/no-image.jpg';
  }


  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

}
