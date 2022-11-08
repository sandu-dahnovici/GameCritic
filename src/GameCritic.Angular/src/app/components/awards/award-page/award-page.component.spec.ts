import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AwardPageComponent } from './award-page.component';

describe('AwardPageComponent', () => {
  let component: AwardPageComponent;
  let fixture: ComponentFixture<AwardPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AwardPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AwardPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
