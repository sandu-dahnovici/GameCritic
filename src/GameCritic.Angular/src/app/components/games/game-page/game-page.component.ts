import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { merge, tap } from 'rxjs';
import { Game } from 'src/app/models/game/game';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { Review } from 'src/app/models/review/review';
import { GameService } from 'src/app/services/game.service';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { ReviewCardComponent } from '../../reviews/review-card/review-card.component';

@Component({
  selector: 'app-game-page',
  templateUrl: './game-page.component.html',
  styleUrls: ['./game-page.component.css']
})
export class GamePageComponent implements OnInit {
  game!: Game;
  pagedReviews?: PagedResult<Review>;
  dataSource = new MatTableDataSource<Review>([]);
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(ReviewCardComponent) reviewCard: ReviewCardComponent;

  constructor(private gameService: GameService, private route: ActivatedRoute,
    private reviewService: ReviewService,
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ game }) => {
      this.game = game;
      this.reviewService.getPagedReviewsByGameId(this.game.id, this.defaultPaginatedRequest)
        .subscribe((pagedResult) => {
          this.pagedReviews = pagedResult;
          this.dataSource = new MatTableDataSource<Review>(pagedResult.items);
        });
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
    this.paginator.page.pipe(
      tap(() => {
        this.reviewService.getPagedReviewsByGameId(this.game.id,
          new PaginatedRequest(this.paginator, '', '', { path: 'comment', value: '' }))
          .subscribe((pagedResult) => {
            this.pagedReviews = pagedResult;
            this.dataSource = new MatTableDataSource<Review>(pagedResult.items);
          });
      })
    ).subscribe();
  }

  isAdmin() {
    return this.userService.isAdmin();
  }

  writeReview() {
    let reviewId: number = 0;
    this.reviewService.getReviewIdByGameAndUserId(this.game.id, this.userService.getUserId())
      .subscribe((id) => {
        reviewId = id;
        this.router.navigateByUrl(`editReview/${reviewId}/games/${this.game.id}`);
      });
  }

  defaultPaginatedRequest: PaginatedRequest = {
    pageIndex: 0,
    pageSize: 3,
    columnNameForSorting: "",
    sortDirection: "",
    filter: {
      path: "comment",
      value: ""
    }
  }
}
