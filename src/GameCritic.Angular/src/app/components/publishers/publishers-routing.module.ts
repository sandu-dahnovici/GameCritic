import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublishersSearchPageComponent } from './publishers-search-page/publishers-search-page.component';

const routes: Routes = [{ path: '', component: PublishersSearchPageComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublishersRoutingModule { }
