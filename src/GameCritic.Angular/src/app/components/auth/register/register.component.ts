import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterUser } from 'src/app/models/user/register-user';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  hide: boolean = true;

  constructor(private formBuilder: FormBuilder,
    private userService : UserService,
    private router : Router) {

  }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ["", [Validators.required]],
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required]],
    });
  }



  submitRegister() {
    if (!this.registerForm.get('email')?.valid || !this.registerForm.get('password')?.valid
    || !this.registerForm.get('username')?.valid) return;

    this.userService
      .registerUser({
        ...this.registerForm.value
      } as RegisterUser)
      .subscribe((user) => {
        if (!user) return;
        this.router.navigate(['/login']).then(() => {
          window.location.reload();
        });
      });
  }

}
