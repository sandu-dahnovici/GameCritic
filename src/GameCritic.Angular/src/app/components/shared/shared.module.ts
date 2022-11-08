import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { GamesGridComponent } from './games-grid/games-grid.component';
import { ScoreButtonComponent } from './score-button/score-button.component';



@NgModule({
  declarations: [
    SearchBarComponent,
    ConfirmDialogComponent,
    GamesGridComponent,
    ScoreButtonComponent,
  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    FormsModule,
    RouterModule,
    MatButtonModule,
    MatDialogModule,
    MatCardModule,
  ],
  exports: [
    SearchBarComponent,
    ConfirmDialogComponent,
    GamesGridComponent,
    ScoreButtonComponent,
  ]
})
export class SharedModule { }
