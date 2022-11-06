import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Publisher } from 'src/app/models/publisher/publisher';

@Component({
  selector: 'app-publisher-page',
  templateUrl: './publisher-page.component.html',
  styleUrls: ['./publisher-page.component.css']
})
export class PublisherPageComponent implements OnInit {
  publisher: Publisher;
  constructor(private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.route.data.subscribe(({ publisher }) => {
      this.publisher = publisher;
    });
  }

}
