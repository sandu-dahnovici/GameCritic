import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Review } from 'src/app/models/review/review';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';

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
    private router: Router) { }

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

  writeReview() {
    let reviewId: number = 0;
    this.reviewService.getReviewIdByGameAndUserId(this.gameId, this.userService.getUserId())
      .subscribe((id) => {
        reviewId = id;
        this.router.navigateByUrl(`reviews/games/${this.gameId}/users/${this.userService.getUserId()}/${reviewId}`);
      });
  }
} 
