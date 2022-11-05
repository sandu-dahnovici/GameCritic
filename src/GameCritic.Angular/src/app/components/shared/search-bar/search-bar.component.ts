import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.css']
})
export class SearchBarComponent implements OnInit {

  @Output() onSearch: EventEmitter<string> = new EventEmitter();
  text: string;
  @Input() entity: string;

  constructor() { }

  ngOnInit(): void {
  }

  search() {
    this.onSearch.emit(this.text);
  }
}
