import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamePageComponent } from './components/games/game-page/game-page.component';
import { GamePageResolver } from './components/games/game-page/game-page.resolver';
import { GamesSearchPageComponent } from './components/games/games-search-page/games-search-page.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'games', component: GamesSearchPageComponent },
  {
    path: 'games/:id',
    component: GamePageComponent,
    resolve: {
      game: GamePageResolver
    },
  },
  { path: '', redirectTo: '/home', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
