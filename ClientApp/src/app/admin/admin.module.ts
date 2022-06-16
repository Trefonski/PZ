import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AdminDashboardComponent } from './dashboard/admin-dashboard.component';
import { AdminDashboardTileComponent } from './dashboard-tile/admin-dashboard-tile.component';
import { AuthGuard } from './../shared/guards/auth.guard';
import { CommonModule } from '@angular/common';
//import { AgGridModule } from 'ag-grid-angular';

export function tokenGetter():string {
  return localStorage.getItem("token") || '';
}
@NgModule({
  declarations: [
    AdminDashboardComponent,
    AdminDashboardTileComponent
  ],
  imports: [
    //AgGridModule,
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] }
    ])
  ],
  providers: []
})
export class AdminModule { }
