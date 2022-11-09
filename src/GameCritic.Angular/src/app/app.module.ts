import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatDividerModule } from '@angular/material/divider';
import { MatNativeDateModule } from '@angular/material/core';
import { NavbarComponent } from './components/navigation/navbar/navbar.component';
import { NgImageSliderModule } from 'ng-image-slider';
import { ProgressBarComponent } from './components/progress-bar/progress-bar.component';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { DelayInterceptor } from './interceptors/delay.interceptor';
import { ProgressInterceptor } from './interceptors/progress.interceptor';
import { SharedModule } from './components/shared/shared.module';
import { HomeComponent } from './components/home/home.component';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { AwardPageComponent } from './components/awards/award-page/award-page.component';
import { AwardsModule } from './components/awards/awards.module';
import { RegisterComponent } from './components/auth/register/register.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';
import { LoginComponent } from './components/auth/login/login.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { UserPageComponent } from './components/users/user-page/user-page.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    ProgressBarComponent,
    RegisterComponent,
    LoginComponent,
    UserPageComponent,
  ],
  imports: [
    SharedModule,
    AppRoutingModule,
    AwardsModule,
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatInputModule,
    HttpClientModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatGridListModule,
    MatDividerModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatSnackBarModule,
    NgImageSliderModule,
    MatProgressBarModule,
    MatCardModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: ProgressInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: DelayInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
