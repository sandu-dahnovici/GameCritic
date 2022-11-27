import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AwardPageComponent } from './components/awards/award-page/award-page.component';
import { AwardResolver } from './components/awards/award-page/award.resolver';
import { GamePageResolver } from './components/games/game-page/game-page.resolver';
import { HomeComponent } from './components/home/home.component';
import { EditReviewComponent } from './components/reviews/edit-review/edit-review.component';
import { NotFoundPageComponent } from './components/shared/not-found-page/not-found-page.component';
import { UserPageResolver } from './components/users/user-page.resolver';
import { UserPageComponent } from './components/users/user-page/user-page.component';
import { AdminGuard } from './guards/admin.guard';
import { UserGuard } from './guards/user.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'publishers', loadChildren: () => import('./components/publishers/publishers.module').then(m => m.PublishersModule) },
  { path: 'games', loadChildren: () => import('./components/games/games.module').then(m => m.GamesModule) },
  { path: 'admin', loadChildren: () => import('./components/admin/admin.module').then(m => m.AdminModule), canActivate: [AdminGuard] },
  { path: 'genres', loadChildren: () => import('./components/genres/genres.module').then(m => m.GenresModule) },
  { path: 'editReview/:id', component: EditReviewComponent, canActivate: [UserGuard] },
  { path: 'awards/:id', component: AwardPageComponent, resolve: { award: AwardResolver } },
  { path: 'users/:id', component: UserPageComponent, resolve: { user: UserPageResolver }, },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', pathMatch: 'full', component: NotFoundPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled',
  }),
    CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
