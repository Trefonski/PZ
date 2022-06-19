import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgControl } from '@angular/forms';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';

@Component({
  selector: 'app-items-view',
  templateUrl: './items-view.component.html',
  styleUrls: ['./items-view.component.css']
})
export class ItemsViewComponent{
  httpClient: any;
  items: Items[] = [];
  

 constructor(private http: HttpClient, private envUrl: EnvironmentUrlService) {
  
   http.get<Items[]>(`${this.envUrl.urlAddress}/Items/GetItemsAllJson`).subscribe(result => {
    this.items = result;
   })
 }
 addToCart(){
  localStorage.setItem('item', JSON.stringify(this.items as {}));

}
}

interface Items {
  iD_Item: string;
  iD_Brand: number;
  size: number;
  colour: string;
  style: string;
  stock: number;
  itemName: string;
  sex: number;
  discout: number;
  nettPrice: number;
  vat: number;
}
