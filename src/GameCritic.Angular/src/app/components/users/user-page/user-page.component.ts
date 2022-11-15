import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user/user';
import { UserDetails } from 'src/app/models/user/user-details';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {

  user: UserDetails | undefined;
  constructor(
    private reviewService: ReviewService,
    private userService: UserService,
    private route: ActivatedRoute
  ) {
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.userService.getUserDetails(params['id']).subscribe((userWithDetails) => {
        this.user = {
          id: userWithDetails?.id,
          username: userWithDetails?.username,
          email: userWithDetails?.email,
          registerDateTime: userWithDetails?.registerDateTime,
          reviewCount: userWithDetails.reviewCount,
          score: userWithDetails.score,
        }
      });
    });
  }

}

