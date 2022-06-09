import { Component, Inject, Input } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-user-returns',
  templateUrl: './user-returns.component.html',
  styleUrls: ['./user-returns.component.css']

})
export class UserReturnsComponent {
  isLogged = false;

  constructor(private authService: AuthenticationService){
    this.isLogged = this.authService.isUserAuthenticated();
  }


}
