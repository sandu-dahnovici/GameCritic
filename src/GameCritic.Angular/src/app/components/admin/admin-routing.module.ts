import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditGameComponent } from './games/edit-game/edit-game.component';
import { UploadGameImageComponent } from './games/upload-game-image/upload-game-image.component';
import { EditPublisherComponent } from './publishers/edit-publisher/edit-publisher.component';


const routes: Routes = [
  { path: 'uploadGameImage/:id', component: UploadGameImageComponent },
  { path: 'editGame/:id', component: EditGameComponent, },
  { path: 'editPublisher/:id', component: EditPublisherComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
