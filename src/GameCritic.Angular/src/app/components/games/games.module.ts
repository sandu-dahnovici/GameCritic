import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GamesRoutingModule } from './games-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTooltipModule } from '@angular/material/tooltip';
import { GamePageComponent } from './game-page/game-page.component';
import { GamesSearchPageComponent } from './games-search-page/games-search-page.component';
import { GamesTableComponent } from './games-table/games-table.component';
import { SharedModule } from '../shared/shared.module';
import { AwardsModule } from '../awards/awards.module';
import { TimelapsePipe } from './game-page/timelapse.pipe';
import { ReviewsModule } from '../reviews/reviews.module';


@NgModule({
  declarations: [
    GamePageComponent,
    GamesSearchPageComponent,
    GamesTableComponent,
    TimelapsePipe
  ],
  imports: [
    SharedModule,
    AwardsModule,
    ReviewsModule,
    CommonModule,
    GamesRoutingModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatDialogModule,
    MatExpansionModule,
    MatMenuModule,
    MatDividerModule,
    MatSelectModule,
    MatSliderModule,
    MatIconModule,
    MatNativeDateModule,
    MatChipsModule,
    MatSortModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatDialogModule,
    MatTooltipModule
  ],
  exports: [
    GamePageComponent,
    GamesSearchPageComponent,
    GamesTableComponent,
  ]
})
export class GamesModule { }
