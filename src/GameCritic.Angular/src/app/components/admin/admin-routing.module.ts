import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EditGameComponent } from './games/edit-game/edit-game.component';
import { UploadGameImageComponent } from './upload-game-image/upload-game-image.component';


const routes: Routes = [
  { path: 'uploadGameImage/:id', component: UploadGameImageComponent },
  { path: 'editGame/:id', component: EditGameComponent, },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
