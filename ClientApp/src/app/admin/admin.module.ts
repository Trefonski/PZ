import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AdminDashboardComponent } from './dashboard/admin-dashboard.component';
import { AdminDashboardTileComponent } from './dashboard-tile/admin-dashboard-tile.component';
import { AuthGuard } from './../shared/guards/auth.guard';
import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';
import { ItemsManagementComponent } from './items-management/items-management.component';
import { ItemAddModalComponent } from './item-add-modal/item-add-modal.component';

export function tokenGetter():string {
  return localStorage.getItem("token") || '';
}
@NgModule({
  declarations: [
    AdminDashboardComponent,
    AdminDashboardTileComponent,
    ItemAddModalComponent,
    ItemsManagementComponent
  ],
  imports: [
    AgGridModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] },
      { path: 'items-management', component: ItemsManagementComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: []
})
export class AdminModule { }
