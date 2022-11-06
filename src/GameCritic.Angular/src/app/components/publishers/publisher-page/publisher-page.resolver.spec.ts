import { TestBed } from '@angular/core/testing';

import { PublisherPageResolver } from './publisher-page.resolver';

describe('PublisherPageResolver', () => {
  let resolver: PublisherPageResolver;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    resolver = TestBed.inject(PublisherPageResolver);
  });

  it('should be created', () => {
    expect(resolver).toBeTruthy();
  });
});
