import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { NgControl } from '@angular/forms';

@Component({
  selector: 'app-items-view',
  templateUrl: './items-view.component.html',
  styleUrls: ['./items-view.component.css']
})
export class ItemsViewComponent implements OnInit{
 items: any = [];

 constructor(private httpClient: HttpClient){}
   
   ngOnInit() {
     this.httpClient.get("https://localhost:44432/assets/item.json").subscribe(data =>{
       this.items = data;
       console.log(this.items.ID_Item);
     })
   }
  }

