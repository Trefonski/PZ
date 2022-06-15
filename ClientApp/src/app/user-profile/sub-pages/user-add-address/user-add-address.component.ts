import { Component, Inject, Input } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-add-address',
  templateUrl: './user-add-address.component.html',
  styleUrls: ['./user-add-address.component.css']


})
export class UserAddAddressComponent {
  isLogged = false;

  constructor(private authService: AuthenticationService){
    this.isLogged = this.authService.isUserAuthenticated();
  }

}
