import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GamesSearchPageComponent } from './games-search-page.component';

describe('GamesSearchPageComponent', () => {
  let component: GamesSearchPageComponent;
  let fixture: ComponentFixture<GamesSearchPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GamesSearchPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GamesSearchPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
