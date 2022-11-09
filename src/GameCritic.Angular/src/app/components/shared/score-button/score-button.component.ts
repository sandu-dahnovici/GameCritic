import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-score-button',
  templateUrl: './score-button.component.html',
  styleUrls: ['./score-button.component.css']
})
export class ScoreButtonComponent implements OnInit {
  @Input("score") score : number;
  @Input("isScore") isScore : boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

}
