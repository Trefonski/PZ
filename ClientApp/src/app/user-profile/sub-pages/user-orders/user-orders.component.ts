import { Component, Inject, Input } from '@angular/core';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-user-orders',
  templateUrl: './user-orders.component.html',
  styleUrls: ['./user-orders.component.css']

})
export class UserOrdersComponent {
  isLogged = false;

  constructor(private authService: AuthenticationService){
    this.isLogged = this.authService.isUserAuthenticated();
  }


}
