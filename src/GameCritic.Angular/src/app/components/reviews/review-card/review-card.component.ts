import { Component, Input, OnInit } from '@angular/core';
import { Review } from 'src/app/models/review/review';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css']
})
export class ReviewCardComponent implements OnInit {
  @Input() review!: Review;
  constructor(private userService: UserService) { }

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
} 
