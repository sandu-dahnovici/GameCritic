import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterModule, RouterStateSnapshot, UrlTree } from '@angular/router';
import { config, Observable } from 'rxjs';
import { SnackService } from '../services/snack.service';
import { UserService } from '../services/user.service';

@Injectable({
  providedIn: 'root'
})
export class AdminGuard implements CanActivate {

  constructor(private userService: UserService, private router: Router,
    private snackbar: SnackService) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    if (this.userService.isAdmin())
      return true;
    this.router.navigate(['/login']).then(() => {
      this.snackbar.openSnack("Login please as admin!", false);
    });
    return false;
  }
}
