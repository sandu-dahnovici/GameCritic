import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GenreResolver } from './genre.resolver';
import { GenresComponent } from './genres.component';

const routes: Routes = [{ path: ':id', component: GenresComponent,resolve:{genre : GenreResolver} }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class GenresRoutingModule { }
