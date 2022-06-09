import { Component, Inject, Input } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']

})
export class UserDataComponent {
  isLogged = false;

  constructor(private authService: AuthenticationService){
    this.isLogged = this.authService.isUserAuthenticated();
  }

}
