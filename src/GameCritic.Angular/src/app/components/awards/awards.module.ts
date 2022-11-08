import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormatAwardPipe } from './format-award.pipe';
import { AwardPageComponent } from './award-page/award-page.component';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    FormatAwardPipe,
    AwardPageComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [
    FormatAwardPipe,
    AwardPageComponent,
  ]
})
export class AwardsModule { }
