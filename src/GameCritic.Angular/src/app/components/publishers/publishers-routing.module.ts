import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublisherPageComponent } from './publisher-page/publisher-page.component';
import { PublisherPageResolver } from './publisher-page/publisher-page.resolver';
import { PublishersSearchPageComponent } from './publishers-search-page/publishers-search-page.component';

const routes: Routes = [
  { path: '', component: PublishersSearchPageComponent },
  { path: ':id', component: PublisherPageComponent, resolve: { publisher: PublisherPageResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PublishersRoutingModule { }
