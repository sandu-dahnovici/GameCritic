import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';
import { Observable, catchError, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginUser } from '../models/user/login-user';
import { RegisterUser } from '../models/user/register-user';
import { User } from '../models/user/user';
import { UserDetails } from '../models/user/user-details';
import { ErrorHandlingService } from './error-handling.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = environment.apiUrl + 'user';
  private user?: User = undefined;

  constructor(
    private http: HttpClient,
    private errorHandler: ErrorHandlingService
  ) {
    this.user = this.getLocalUser();
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  loginUser(registerUser: LoginUser): Observable<User> {
    const url = `${this.url}/login`;
    return this.http
      .post<User>(url, registerUser, this.httpOptions)
      .pipe(catchError(this.errorHandler.handleError<User>()))
      .pipe(
        map((user) => {
          this.saveUser(user);
          return user;
        })
      );
  }

  registerUser(loginUser: RegisterUser): Observable<User> {
    const url = `${this.url}/register`;
    return this.http
      .post<User>(url, loginUser, this.httpOptions)
      .pipe(catchError(this.errorHandler.handleError<User>()));
  }

  logoutUser(): void {
    localStorage.removeItem('user');
    this.user = undefined;
  }

  private saveUser(user?: User) {
    if (!user) return;
    localStorage.setItem('user', JSON.stringify(user));
    this.user = user;
  }


  isUser(): boolean {
    if (this.user == undefined) return false;

    return this.user?.role == 'User';
  }

  isAdmin(): boolean {
    if (!this.user) return false;
    return this.user?.role == 'Admin';
  }

  private getLocalUser(): User | undefined {
    const userStr = localStorage.getItem('user');
    if (userStr) return JSON.parse(userStr) as User;
    return undefined;
  }


  getToken(): string {
    if (this.user) {
      if (this.user.token) return this.user.token;
    }
    return '';
  }

  getUsername() {
    return this.user?.username;
  }

  getUserId() {
    return this.user?.id;
  }

  getUser() {
    return this.user;
  }

  getUserDetails(id: number | string | undefined): Observable<UserDetails> {
    return this.http.get<UserDetails>(this.url + `/user-details/` + `${id}`)
      .pipe(catchError(this.errorHandler.handleError<UserDetails>()));
  }

}
