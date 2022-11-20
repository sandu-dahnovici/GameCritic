import { AfterViewInit, ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgImageSliderComponent } from 'ng-image-slider';
import { delay } from 'rxjs';
import { GameList } from 'src/app/models/game/game-list';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { GameService } from 'src/app/services/game.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit, AfterViewInit {
  games: GameList[] = [];
  imgCollection: Array<ImageObject> = [];
  
  @ViewChild(NgImageSliderComponent) slider: NgImageSliderComponent;

  constructor(private gameService: GameService,
    public route: ActivatedRoute, public router: Router,
    private cd: ChangeDetectorRef) { }

  ngOnInit(): void {
    const paginatedRequest: PaginatedRequest = {
      pageIndex: 0,
      pageSize: 14,
      columnNameForSorting: '',
      sortDirection: '',
      filter: {
        path: 'title',
        value: '',
      }
    };

    this.gameService.getGamesPaged(paginatedRequest).subscribe((pagedGames: PagedResult<GameList>) => {
      this.games = pagedGames.items;
      for (let game of this.games) {
        this.imgCollection.push({
          image: this.gameService.getGameImageUrl(game.imageName),
          title: game.title,
          alt: game.title,
          thumbImage: this.gameService.getGameImageUrl(game.imageName),
          id: game.id
        });
      }
    });
  }

  ngAfterViewInit(): void {
    this.slider.imagePopup = false;

    this.cd.detectChanges();
  }

  paginatedSearch(text: string) {
    if (text.length) {
      this.gameService.search = {
        redirected: true,
        text: text
      }
      this.router.navigate(['/games']);
    }
  }

  imageClickHandler(e: number) {
    this.router.navigate(['/games', e + 1]);
  }
}

interface ImageObject {
  image: string,
  title: string,
  alt: string,
  thumbImage: string,
  id: number,
}