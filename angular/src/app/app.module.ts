import { BrowserModule } from '@angular/platform-browser'
import { NgModule } from '@angular/core'
import { FormsModule } from '@angular/forms'
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router'
import {
  MatButtonModule,
  MatCardModule,
  MatGridListModule,
} from '@angular/material'
import { StoreModule } from '@ngrx/store'
import { StoreDevtoolsModule } from '@ngrx/store-devtools'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'

import { AppComponent } from './app.component'
import { NavMenuComponent } from './containers/nav-menu/nav-menu.component'
import { HomeComponent } from './containers/home/home.component'
import { CartComponent } from './containers/cart/cart.component'
import { CartItemsComponent } from './containers/cart/cart-items/cart-items.component'
import { ProductComponent } from './containers/product/product.component'
import { OrderService } from './services/order.service'
import { ProductService } from './services/product.service'
import { ShoppingReducer } from './store/shopping.reducer'
import { environment } from '../environments/environment'
import { OrderDetailComponent } from './containers/order/order-detail/order-detail.component'
import { OrderListComponent } from './containers/order/order-list/order-list.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CartComponent,
    CartItemsComponent,
    ProductComponent,
    CartComponent,
    OrderDetailComponent,
    OrderListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'product', component: ProductComponent },
      { path: 'cart-detail', component: CartComponent },
      { path: 'order-detail/:id', component: OrderDetailComponent },
    ]),
    BrowserAnimationsModule,
    StoreModule.forRoot({
      shopping: ShoppingReducer,
    }),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: environment.production,
    }),
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
  ],
  providers: [OrderService, ProductService],
  bootstrap: [AppComponent],
})
export class AppModule {}
