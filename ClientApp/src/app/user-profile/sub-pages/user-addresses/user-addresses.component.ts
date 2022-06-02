import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-user-addresses',
  templateUrl: './user-addresses.component.html',
  styleUrls: ['./user-addresses.component.css']

})
export class UserAddressesComponent {
  public addresses: Adressess[] = []

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      http.get<Adressess[]>(baseUrl + 'addresses').subscribe(result => {
        this.addresses = result;
      }, error => console.error(error));


  }
}

interface Adressess {
  city: string;
  voivodeship: string;
  coutry: string;
  postcode: string;
  blockno: number;
  houseno: number;
  }
