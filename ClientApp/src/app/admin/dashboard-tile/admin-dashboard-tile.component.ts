import { Component, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'div[admin-dashboard-tile]',
  templateUrl: './admin-dashboard-tile.component.html',
  styleUrls: ['./admin-dashboard-tile.component.css'],
  host: { 'class': 'col-12 col-sm-6 col-md-4 col-lg-3' }
})
export class AdminDashboardTileComponent {
    @Input() link:string
    @Input() name:string

    constructor() {
        this.link = '';
        this.name = '';
    }
}
