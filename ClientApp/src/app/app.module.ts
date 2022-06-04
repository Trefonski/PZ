import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AdminDashboardComponent } from './admin/dashboard/admin-dashboard.component';
import { AdminDashboardTileComponent } from './admin/dashboard-tile/admin-dashboard-tile.component';
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './shared/guards/auth.guard';
import { SideNavMenuComponent } from './user-profile/side-nav-menu/side-nav-menu.component';
import { UserAddAddressComponent } from './user-profile/sub-pages/user-add-address/user-add-address.component';
import { UserAddressesComponent } from './user-profile/sub-pages/user-addresses/user-addresses.component';
import { UserOrdersComponent } from './user-profile/sub-pages/user-orders/user-orders.component';
import { UserReturnsComponent } from './user-profile/sub-pages/user-returns/user-returns.component';
import { UserDataComponent } from './user-profile/sub-pages/user-data/user-data.component';
//import { CartComponent } from './cart/cart.component';


export function tokenGetter():string {
  return localStorage.getItem("token") || '';
}
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AdminDashboardComponent,
    AdminDashboardTileComponent,
    SideNavMenuComponent,
    UserAddressesComponent,
    UserAddAddressComponent,
    UserOrdersComponent,
    UserDataComponent,
    UserReturnsComponent,
    //CartComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        allowedDomains: [],
        disallowedRoutes: [],
        tokenGetter: tokenGetter
      }      
    }),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'admin-dashboard', component: AdminDashboardComponent, canActivate: [AuthGuard] },
      { path: 'addresses', component: UserAddressesComponent },
      { path: 'add-addresses', component: UserAddAddressComponent },
      { path: 'orders', component: UserOrdersComponent },
      { path: 'user-data', component: UserDataComponent },
      //{ path: 'returns', component: UserReturnsComponent },
      //{ path: 'cart', component: CartComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
