import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { RegisterComponent } from './components/auth/register/register.component';
import { AwardPageComponent } from './components/awards/award-page/award-page.component';
import { AwardResolver } from './components/awards/award-page/award.resolver';
import { HomeComponent } from './components/home/home.component';
import { AdminGuard } from './guards/admin.guard';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'publishers', loadChildren: () => import('./components/publishers/publishers.module').then(m => m.PublishersModule) },
  { path: 'games', loadChildren: () => import('./components/games/games.module').then(m => m.GamesModule) },
  { path: 'admin', loadChildren: () => import('./components/admin/admin.module').then(m => m.AdminModule), canActivate: [AdminGuard] },
  { path: 'genres', loadChildren: () => import('./components/genres/genres.module').then(m => m.GenresModule) },
  { path: 'awards/:id', component: AwardPageComponent, resolve: { award: AwardResolver } },
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {
    scrollPositionRestoration: 'enabled',
  }),
    CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
