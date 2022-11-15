import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Review } from 'src/app/models/review/review';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { ConfirmDialogComponent } from '../../shared/confirm-dialog/confirm-dialog.component';

@Component({
  selector: 'app-review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css']
})
export class ReviewCardComponent implements OnInit {
  @Input() review!: Review;
  @Input() gameId: number;

  constructor(private userService: UserService,
    private reviewService: ReviewService,
    private router: Router,
    private snackBar: MatSnackBar,
    public dialog: MatDialog,
    private activeRoute: ActivatedRoute) { }

  ngOnInit(): void {
  }

  isAdmin() {
    return this.userService.isAdmin();
  }

  isUsersReview() {
    return this.userService.getUsername() == this.review.user.username;
  }

  displayDeleteButton() {
    return this.isAdmin() || this.isUsersReview();
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

  redirectToUserPage() {
    this.router.navigate(['/users', this.review.user.id]);
  }

  writeReview() {
    let reviewId: number = 0;
    this.reviewService.getReviewIdByGameAndUserId(this.gameId, this.userService.getUserId())
      .subscribe((id) => {
        reviewId = id;
        this.router.navigateByUrl(`editReview/${reviewId}/games/${this.gameId}`);
      });
  }

  reloadCurrentPage() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
} 
