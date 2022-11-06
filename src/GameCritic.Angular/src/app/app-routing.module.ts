import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'publishers', loadChildren: () => import('./components/publishers/publishers.module').then(m => m.PublishersModule) },
  { path: 'games', loadChildren: () => import('./components/games/games.module').then(m => m.GamesModule) },
  { path: 'admin', loadChildren: () => import('./components/admin/admin.module').then(m => m.AdminModule) },
  { path: 'genres', loadChildren: () => import('./components/genres/genres.module').then(m => m.GenresModule) },
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
