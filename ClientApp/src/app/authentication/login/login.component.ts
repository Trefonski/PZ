import { HttpErrorResponse } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from './../../shared/services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserForAuthentication } from 'src/app/interfaces/userForAuthentication.interface';
import { AuthResponse } from 'src/app/interfaces/authResponse.interface';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit {
  private returnUrl: string;
  
  loginForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) {
    this.loginForm = new FormGroup({});  
    this.returnUrl = '';
    this.showError = false;
   }
  
  ngOnInit(): void {
    this.loginForm = new FormGroup({
      username: new FormControl("", [Validators.required]),
      password: new FormControl("", [Validators.required])
    })
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  validateControl = (controlName: string) => {
    const controlValue = this.loginForm.get(controlName)
    return controlValue && controlValue.invalid && controlValue.touched
  }

  hasError = (controlName: string, errorName: string) => {
    const controlValue = this.loginForm.get(controlName)
    return controlValue && controlValue.hasError(errorName)
  }
  
  loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = {...loginFormValue};

    const userForAuth: UserForAuthentication = {
      email: login.username,
      password: login.password
    }

    this.authService.loginUser('api/accounts/login', userForAuth)
    .subscribe({
      next: (res:AuthResponse) => {
       localStorage.setItem("token", res.token);
       this.authService.sendAuthStateChangeNotification(res.isAuthSuccessful);
       this.router.navigate([this.returnUrl]);
    },
    error: (err: HttpErrorResponse) => {
      this.errorMessage = err.message;
      this.showError = true;
    }})
  }
}