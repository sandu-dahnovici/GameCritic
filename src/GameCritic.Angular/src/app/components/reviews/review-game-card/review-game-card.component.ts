import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ReviewGame } from 'src/app/models/review/review-game';
import { GameService } from 'src/app/services/game.service';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-review-game-card',
  templateUrl: './review-game-card.component.html',
  styleUrls: ['./review-game-card.component.css']
})
export class ReviewGameCardComponent implements OnInit {
  @Input() review!: ReviewGame;
  @Input() userId: number;

  constructor(private userService: UserService,
    private reviewService: ReviewService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog,
    private gameService: GameService) { }

  ngOnInit(): void {
  }


  openDialogForDeleting(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to delete this review?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.reviewService.deleteReview(id).subscribe(
          () => {
            this.snackBar.open('The review has been deleted successfully.', 'Close', {
              duration: 1500
            });
            this.reloadCurrentPage();
          }
        );
      }
    });
  }

  isCurrentUsersPage() {
    return this.userService.getUserId() == this.userId;
  }

  redirectToGamePage() {
    this.router.navigate(['/games', this.review.game.id]);
  }

  writeReview() {
    let reviewId: number | undefined = 0;
    this.reviewService.getReviewByGameAndUserId(this.review.game.id, this.userService.getUserId())
      .subscribe((review) => {
        reviewId = review.id;
        this.router.navigateByUrl(`editReview/${reviewId}`);
      });
  }

  reloadCurrentPage() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  getImageUrl(imageName?: string) {
    if (imageName) {
      return this.gameService.getGameImageUrl(imageName);
    }
    return 'assets/no-image.jpg';
  }

}
