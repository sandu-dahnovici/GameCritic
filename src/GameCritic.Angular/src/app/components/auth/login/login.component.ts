import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/models/user/login-user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  hide: boolean = true;
  constructor(private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required,Validators.minLength(6)]],
    });
  }

  submitLogIn() {
    if (!this.loginForm.get('email')?.valid || !this.loginForm.get('password')?.valid) return;

    this.userService
      .loginUser({
        ...this.loginForm.value
      } as LoginUser)
      .subscribe((user) => {
        if (!user) return;
        this.router.navigate(['/']).then(() => {
          window.location.reload();
        });
      });
  }
}
