import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs'
import { Store } from '@ngrx/store'

import { ShoppingItem } from '../../../contracts/shoppingItem'
import { AppState } from '../../../store/app-state'
import {
  DeleteItemAction,
  UpdateItemAction,
} from '../../../store/shopping.actions'
import { ShoppingService } from 'src/app/services/shopping.service'

@Component({
  selector: 'app-cart-items',
  templateUrl: './cart-items.component.html',
})
export class CartItemsComponent implements OnInit {
  shoppingItems$: Observable<ShoppingItem[]>
  quantities: any[] = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]

  constructor(
    private store: Store<AppState>,
    private shoppingService: ShoppingService,
  ) {}

  ngOnInit() {
    this.shoppingItems$ = this.store.select((store) => store.shopping)
  }

  removeItemFromCart(id: any): void {
    this.store.dispatch(new DeleteItemAction(id))
  }

  async onQuantityChange(shoppingItem: ShoppingItem) {
    const quantity: number = Number(shoppingItem.quantity)
    const priceCalculation = await this.shoppingService.getItemPrice(
      shoppingItem.product.id,
      quantity,
    )

    shoppingItem.quantity = quantity
    shoppingItem.price = priceCalculation.price
    shoppingItem.promotionApplied = priceCalculation.promotionApplied

    this.store.dispatch(new UpdateItemAction(shoppingItem))
  }
}
