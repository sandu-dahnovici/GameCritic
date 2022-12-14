import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReviewCardComponent } from './review-card/review-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { SharedModule } from '../shared/shared.module';
import { EditReviewComponent } from './edit-review/edit-review.component';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatSliderModule } from '@angular/material/slider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { ReviewGameCardComponent } from './review-game-card/review-game-card.component';



@NgModule({
  declarations: [
    ReviewCardComponent,
    EditReviewComponent,
    ReviewGameCardComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    SharedModule,
    MatButtonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule,
    MatSliderModule,
    MatIconModule,
    MatInputModule,
    MatToolbarModule,
    MatSnackBarModule,
  ],
  exports: [
    ReviewCardComponent,
    ReviewGameCardComponent
  ]
})
export class ReviewsModule { }
