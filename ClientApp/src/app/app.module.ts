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
import { JwtModule } from '@auth0/angular-jwt';
import { AuthGuard } from './shared/guards/auth.guard';
import { SideNavMenuComponent } from './user-profile/side-nav-menu/side-nav-menu.component';
import { UserAddAddressComponent } from './user-profile/sub-pages/user-add-address/user-add-address.component';
import { UserAddressesComponent } from './user-profile/sub-pages/user-addresses/user-addresses.component';
import { UserOrdersComponent } from './user-profile/sub-pages/user-orders/user-orders.component';
import { UserReturnsComponent } from './user-profile/sub-pages/user-returns/user-returns.component';
import { UserDataComponent } from './user-profile/sub-pages/user-data/user-data.component';
import { ItemsNavComponent } from './items-view/items-nav/items-nav.component';
import { ItemsViewComponent } from './items-view/items-view.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { CartComponent } from './cart/cart.component';
import { FooterComponent } from './footer/footer.component';
import { HelpComponent } from './user-profile/sub-pages/user-help/user-help.component';
import { ProductOrderComponent  } from './product-order/product-order.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

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
    SideNavMenuComponent,
    UserAddressesComponent,
    UserAddAddressComponent,
    UserOrdersComponent,
    UserDataComponent,
    UserReturnsComponent,
    ItemsNavComponent,
    ItemsViewComponent,
    ItemDetailsComponent,
    CartComponent,
    FooterComponent,
    ProductOrderComponent,
    HelpComponent,
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
    NgbModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'authentication', loadChildren: () => import('./authentication/authentication.module').then(m => m.AuthenticationModule) },
      { path: 'admin', loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule) },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'addresses', component: UserAddressesComponent, canActivate: [AuthGuard]},
      { path: 'add-address', component: UserAddAddressComponent, canActivate: [AuthGuard]},
      { path: 'orders', component: UserOrdersComponent, canActivate: [AuthGuard] },
      { path: 'user-data', component: UserDataComponent, canActivate: [AuthGuard] },
      { path: 'items', component: ItemsViewComponent },
      { path: 'item-details/:id', component: ItemDetailsComponent },
      //{ path: 'returns', component: UserReturnsComponent },
      { path: 'cart', component: CartComponent },
      { path: 'product-order', component: ProductOrderComponent },
      { path: 'help', component: HelpComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
