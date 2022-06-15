import { Router } from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../shared/services/authentication.service';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserForRegistration } from 'src/app/interfaces/userForRegistration.interface';
import { PasswordConfirmationValidatorService } from 'src/app/shared/validators/password-confirmation-validator.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errorMessage: string = '';
  showError: boolean;

  constructor(private authService: AuthenticationService, 
    private passConfValidator: PasswordConfirmationValidatorService, private router: Router) { 
      this.registerForm = new FormGroup({});
      this.showError = false;
    }

  ngOnInit(): void {
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });

    const confirmValue = this.registerForm.get('confirm');
    const passwordValue = this.registerForm.get('password');

    confirmValue && confirmValue.setValidators([Validators.required, 
    this.passConfValidator.validateConfirmPassword(passwordValue as AbstractControl)]);
  }

  public validateControl = (controlName: string) => {
    const controlValue = this.registerForm.get(controlName);
    return controlValue && controlValue.invalid && controlValue.touched
  }

  public hasError = (controlName: string, errorName: string) => {
    const controlValue = this.registerForm.get(controlName);
    return controlValue && controlValue.hasError(errorName)
  }

  public registerUser = (registerFormValue: any) => {
    this.showError = false;
    const formValues = { ...registerFormValue };

    const user: UserForRegistration = {
      FirstName: formValues.firstName,
      LastName: formValues.lastName,
      UserName: formValues.email,
      Password: formValues.password,
      ConfirmPassword: formValues.confirm
    };

    this.authService.registerUser("api/auth/registration", user)
    .subscribe({
      next: (_) => this.router.navigate(["/authentication/login"]),
      error: (err: HttpErrorResponse) => {
        this.errorMessage = err.message;
        this.showError = true;
      }
    })
  }
}