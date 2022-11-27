import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { catchError, tap } from 'rxjs';
import { Game } from 'src/app/models/game/game';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { Review } from 'src/app/models/review/review';
import { GameService } from 'src/app/services/game.service';
import { RankingService } from 'src/app/services/ranking.service';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { ReviewCardComponent } from '../../reviews/review-card/review-card.component';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

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
    private rankingService: RankingService,
    public snackBar: MatSnackBar,
    private router: Router,
    private dialog: MatDialog) { }

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
    let reviewId: number | undefined = 0;
    let userId: number | undefined = 0;

    userId = this.userService.getUserId();
    if (userId != undefined) {
      this.reviewService.getReviewByGameAndUserId(this.game.id, userId)
        .subscribe((review) => {
          if (review != undefined)
            reviewId = review.id;
          this.reviewService.gameIdToReview = this.game.id;
          this.router.navigateByUrl(`editReview/${reviewId}`);
        });
    } else this.router.navigateByUrl(`editReview/${reviewId}`);
  }

  openDialogForDeleting(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to delete this ranking?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.rankingService.deleteRanking(id).subscribe(
          () => {
            this.snackBar.open('The award has been deleted successfully from this game.', 'Close', {
              duration: 1500
            });
            this.delay(1600);
            this.reloadCurrentPage();
          }
        );
      }
    });
  }

  reloadCurrentPage() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  delay(ms: number) {
    return new Promise(resolve => setTimeout(resolve, ms));
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
