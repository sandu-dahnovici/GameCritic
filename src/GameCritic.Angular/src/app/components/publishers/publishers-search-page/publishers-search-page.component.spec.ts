import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PublishersSearchPageComponent } from './publishers-search-page.component';

describe('PublishersSearchPageComponent', () => {
  let component: PublishersSearchPageComponent;
  let fixture: ComponentFixture<PublishersSearchPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PublishersSearchPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PublishersSearchPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
