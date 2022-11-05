import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GamePageComponent } from './game-page/game-page.component';
import { GamePageResolver } from './game-page/game-page.resolver';
import { GamesSearchPageComponent } from './games-search-page/games-search-page.component';

const routes: Routes = [
  { path: '', component: GamesSearchPageComponent },
  { path: ':id', component: GamePageComponent, resolve: { game: GamePageResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GamesRoutingModule { }
