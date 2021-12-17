import { Component, OnInit } from '@angular/core'
import { Router } from '@angular/router'
import { Observable } from 'rxjs'
import { Store } from '@ngrx/store'
import { v4 as uuid } from 'uuid'

import { ShoppingItem } from '../../../contracts/shoppingItem'
import { AppState } from '../../../store/app-state'
import {
  DeleteItemAction,
  DeleteAllItemAction,
  UpdateItemAction,
} from '../../../store/shopping.actions'
import { OrderService } from '../../../services/order.service'
import { ShoppingService } from 'src/app/services/shopping.service'
import { Order } from '../../../contracts/order'

@Component({
  selector: 'app-cart-detail',
  templateUrl: './cart-detail.component.html',
})
export class CartComponentDetail implements OnInit {
  shoppingItems$: Observable<ShoppingItem[]>
  cartSubtotal: number
  items: ShoppingItem[]
  isOrderCreated = false
  order = { shoppingItems: [] } as Order
  quantities: any[] = [1, 2, 3]

  constructor(
    private store: Store<AppState>,
    public router: Router,
    private orderService: OrderService,
    private shoppingService: ShoppingService,
  ) {}

  ngOnInit() {
    this.shoppingItems$ = this.store.select((store) => store.shopping)
    this.calculateSubtotal()
  }

  removeItemFromCart(id: any): void {
    this.store.dispatch(new DeleteItemAction(id))
    this.calculateSubtotal()
  }

  calculateSubtotal(): void {
    this.shoppingItems$.subscribe((x) => (this.items = x))
    this.cartSubtotal = this.items.reduce(
      (accumulator, currentValue) => accumulator + currentValue.price,
      0,
    )
  }

  async onQuantityChange(shoppingItem: ShoppingItem) {
    const quantity: number = Number(shoppingItem.quantity)
    shoppingItem.quantity = quantity
    shoppingItem.price = await this.shoppingService.getItemPrice(
      shoppingItem.product.id,
      quantity,
    )
    
    this.store.dispatch(new UpdateItemAction(shoppingItem))
    this.calculateSubtotal()
  }

  proceedToCheckout(): void {
    const newOrder = new Order()
    newOrder.id = uuid()
    newOrder.date = new Date()
    newOrder.shoppingItems = this.items
    newOrder.total = this.cartSubtotal

    this.orderService.add(newOrder).subscribe(
      (response: any) => (this.order = response),
      (error: any) => {},
      () => {
        this.afterOrderCreated()
      },
    )
  }

  afterOrderCreated(): void {
    this.store.dispatch(new DeleteAllItemAction())
    this.isOrderCreated = true
    this.router.navigate(['/order-detail', this.order.id])
  }
}
