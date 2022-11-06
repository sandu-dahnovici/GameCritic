import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Publisher } from 'src/app/models/publisher/publisher';
import { PublisherService } from 'src/app/services/publisher.service';

@Injectable({
  providedIn: 'root'
})
export class PublisherPageResolver implements Resolve<Publisher> {
  constructor(private service: PublisherService) { }
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Publisher> | Promise<Publisher> | Publisher {
    return this.service.getPublisherById(route.paramMap.get('id') as string);
  }
}
