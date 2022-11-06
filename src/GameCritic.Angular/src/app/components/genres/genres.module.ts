import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { GenresRoutingModule } from './genres-routing.module';
import { GenresComponent } from './genres.component';
import { SharedModule } from '../shared/shared.module';
import { MatCardModule } from '@angular/material/card';


@NgModule({
  declarations: [
    GenresComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatCardModule,
    GenresRoutingModule
  ]
})
export class GenresModule { }
