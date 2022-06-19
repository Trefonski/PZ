import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import * as _ from 'lodash';
import { EnvironmentUrlService } from '../shared/services/environment-url.service';


@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css']
})
export class ItemDetailsComponent {
  httpClient: any;
   item: Items = {} as Items;
  
  constructor(private http: HttpClient, private envUrl: EnvironmentUrlService, private activateRoute: ActivatedRoute) {
  let param1 = this.activateRoute.snapshot.params.id;
;
    http.get<Items>(`${this.envUrl.urlAddress}/Items/GetSingleItemJson`,{params: {ID_Item:param1}}).subscribe(result => {
      this.item = result;
    })
  }
  addToCart(){
    let param1 = this.activateRoute.snapshot.params.id;
    localStorage.setItem(param1, JSON.stringify(this.item));
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
