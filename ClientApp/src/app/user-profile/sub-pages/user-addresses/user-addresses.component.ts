import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';

@Component({
  selector: 'app-user-addresses',
  templateUrl: './user-addresses.component.html',
  styleUrls: ['./user-addresses.component.css']

})
export class UserAddressesComponent {

  isLogged = false;

  constructor(private authService: AuthenticationService){
    this.isLogged = this.authService.isUserAuthenticated();
  }


  }
