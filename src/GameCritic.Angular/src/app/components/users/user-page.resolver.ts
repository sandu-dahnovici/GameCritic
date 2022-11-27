import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { UserDetails } from 'src/app/models/user/user-details';
import { UserService } from 'src/app/services/user.service';

@Injectable({
  providedIn: 'root'
})
export class UserPageResolver implements Resolve<UserDetails> {
  /**
   *
   */
  constructor(private service : UserService) {
    
  }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<UserDetails> | Promise<UserDetails> | UserDetails {
    return this.service.getUserDetails(route.paramMap.get('id') as string);
  }
}
