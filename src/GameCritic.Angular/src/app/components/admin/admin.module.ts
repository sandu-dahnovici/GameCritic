import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing.module';
import { EditGameComponent } from './games/edit-game/edit-game.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatOptionModule } from '@angular/material/core';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { EditPublisherComponent } from './publishers/edit-publisher/edit-publisher.component';
import { UploadGameImageComponent } from './games/upload-game-image/upload-game-image.component';
import { AddAwardComponent } from './games/add-award/add-award.component';
import { SharedModule } from '../shared/shared.module';
import { AwardsModule } from '../awards/awards.module';


@NgModule({
  declarations: [
    UploadGameImageComponent,
    EditGameComponent,
    EditPublisherComponent,
    AddAwardComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    AwardsModule,
    FormsModule,
    MatCardModule,
    MatOptionModule,
    MatSelectModule,
    MatIconModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSnackBarModule,
  ],
  exports: [
    UploadGameImageComponent,
    EditGameComponent
  ]
})
export class AdminModule { }
