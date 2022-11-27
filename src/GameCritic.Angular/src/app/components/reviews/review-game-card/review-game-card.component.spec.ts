import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReviewGameCardComponent } from './review-game-card.component';

describe('ReviewGameCardComponent', () => {
  let component: ReviewGameCardComponent;
  let fixture: ComponentFixture<ReviewGameCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReviewGameCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReviewGameCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
