import { Component } from '@angular/core';
import { Items } from '../items';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  items=Items;
}
