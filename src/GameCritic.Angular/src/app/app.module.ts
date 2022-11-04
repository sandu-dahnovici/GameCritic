import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatSelectModule } from '@angular/material/select';
import { MatSliderModule } from '@angular/material/slider';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatChipsModule } from '@angular/material/chips';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { NavbarComponent } from './components/navigation/navbar/navbar.component';
import { HomeComponent } from './components/home/home.component';
import { SearchBarComponent } from './components/games/search-bar/search-bar.component';
import { NgImageSliderModule } from 'ng-image-slider';
import { GamesSearchPageComponent } from './components/games/games-search-page/games-search-page.component';
import { GamesTableComponent } from './components/games/games-table/games-table.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';
import { MatProgressBarModule } from '@angular/material/progress-bar'
import { DelayInterceptor } from './interceptors/delay.interceptor';
import { ProgressInterceptor } from './interceptors/progress.interceptor';
import { TimelapsePipe } from './components/games/game-page/timelapse.pipe';
import { GamePageComponent } from './components/games/game-page/game-page.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { FormatAwardPipe } from './components/awards/format-award.pipe'


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HomeComponent,
    SearchBarComponent,
    GamesSearchPageComponent,
    GamesTableComponent,
    GamePageComponent,
    ProgressBarComponent,
    TimelapsePipe,
    FormatAwardPipe,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatExpansionModule,
    MatMenuModule,
    MatDividerModule,
    MatSelectModule,
    MatSliderModule,
    MatIconModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatChipsModule,
    NgImageSliderModule,
    MatProgressBarModule,
    MatSortModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatSnackBarModule,
    MatDialogModule,
    MatTooltipModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ProgressInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: DelayInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
