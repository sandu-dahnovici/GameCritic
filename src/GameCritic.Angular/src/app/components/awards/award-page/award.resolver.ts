import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Award } from 'src/app/models/award/award';
import { AwardService } from 'src/app/services/award.service';


@Injectable({
  providedIn: 'root'
})
export class AwardResolver implements Resolve<Award> {
  constructor(private service: AwardService) { }
  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<Award> | Promise<Award> | Award {
    return this.service.getAwardById(route.paramMap.get('id') as string);
  }
}
