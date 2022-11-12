import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Game } from 'src/app/models/game/game';
import { Review } from 'src/app/models/review/review';
import { GameService } from 'src/app/services/game.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-edit-review',
  templateUrl: './edit-review.component.html',
  styleUrls: ['./edit-review.component.css']
})
export class EditReviewComponent implements OnInit {
  public id!: number;
  public gameId: number;
  public gameTitle!: string;
  public pageTitle: string;
  public reviewForm: FormGroup;

  constructor(private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private gameService: GameService,
    private reviewService : ReviewService) { }

  ngOnInit(): void {
    let objectId!: number;
    this.route.params.subscribe(params => {
      objectId = +params['id'];
      this.gameId = +params['gameId'];
      this.gameService.getGameById(this.gameId.toString()).subscribe((game: Game) => {
        this.gameTitle = game.title;
        if (objectId === 0) {
          this.pageTitle = `Add Review for ${this.gameTitle}`;
        } else {
          this.getReview(objectId);
          this.pageTitle = `Edit Review for ${this.gameTitle}`;
          this.id = objectId;
        }
      });
    });

    this.reviewForm = this.formBuilder.group({
      id: [objectId, [Validators.required]],
      comment: [null, [Validators.maxLength(1000)]],
      mark: [null, [Validators.required, Validators.min(1), Validators.max(10)]],
    });
  }

  getReview(id: number): void {
    this.reviewService.getReviewId(id).subscribe((review: Review) => {
      this.reviewForm.controls['comment'].setValue(review.comment);
      this.reviewForm.controls['mark'].setValue(review.mark);
      this.reviewForm.controls['id'].setValue(review.id);
    });
  }

  saveReview() {

  }

  getGameTitle(id: number): void {
    this.gameService.getGameById(id.toString()).subscribe((game: Game) => {
      this.gameTitle = game.title;
    });
  }

  get comment() {
    return this.reviewForm.get('comment');
  }

  get mark() {
    return this.reviewForm.get('mark');
  }

  formatLabel(value: number) {
    return value;
  }
}
