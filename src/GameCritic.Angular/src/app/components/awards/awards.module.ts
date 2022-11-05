import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormatAwardPipe } from './format-award.pipe';


@NgModule({
  declarations: [
    FormatAwardPipe,
  ],
  imports: [
    CommonModule
  ],
  exports: [
    FormatAwardPipe,
  ]
})
export class AwardsModule { }
