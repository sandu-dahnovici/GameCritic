import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { tap } from 'rxjs';
import { PagedResult } from 'src/app/models/pagination/paged-result.model';
import { PaginatedRequest } from 'src/app/models/pagination/paginated-result.model';
import { ReviewGame } from 'src/app/models/review/review-game';
import { UserDetails } from 'src/app/models/user/user-details';
import { ReviewService } from 'src/app/services/review.service';
import { UserService } from 'src/app/services/user.service';
import { ReviewGameCardComponent } from '../../reviews/review-game-card/review-game-card.component';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit, AfterViewInit {

  user!: UserDetails;
  pagedReviews?: PagedResult<ReviewGame>;
  dataSource = new MatTableDataSource<ReviewGame>([]);
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(ReviewGameCardComponent) reviewCard: ReviewGameCardComponent;

  constructor(
    private reviewService: ReviewService,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ user }) => {
      this.user = { ...user }
      this.reviewService.getPagedReviewsByUserId(this.user.id, this.defaultPaginatedRequest)
        .subscribe((pagedResult) => {
          this.pagedReviews = pagedResult;
          this.dataSource = new MatTableDataSource<ReviewGame>(pagedResult.items);
        });
    });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
    this.paginator.page.pipe(
      tap(() => {
        this.reviewService.getPagedReviewsByUserId(this.user?.id,
          new PaginatedRequest(this.paginator, '', '', { path: 'comment', value: '' }))
          .subscribe((pagedResult) => {
            this.pagedReviews = pagedResult;
            this.dataSource = new MatTableDataSource<ReviewGame>(pagedResult.items);
          });
      })
    ).subscribe();
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



