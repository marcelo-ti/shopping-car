import { Component, OnInit } from '@angular/core'
import { select, Store } from '@ngrx/store'
import { v4 as uuid } from 'uuid'
import { take } from 'rxjs/operators'

import { AppState } from '../../store/app-state'
import { ShoppingItem } from 'src/app/contracts/shoppingItem'
import { Product } from '../../contracts/product'
import { ProductService } from '../../services/product.service'
import { ShoppingService } from '../../services/shopping.service'
import { AddItemAction, UpdateItemAction } from '../../store/shopping.actions'

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  products: Product[]
  constructor(
    private store: Store<AppState>,
    private productService: ProductService,
    private shoppingService: ShoppingService,
  ) {}

  ngOnInit() {
    this.productService
      .getAll()
      .subscribe((products) => (this.products = products))
    this.store.select((store) => store.shopping)
  }

  async addToCartAsync(selectedProduct: Product): Promise<void> {
    const shoppingItems = await this.getStateAsync(this.store)

    const productAlreadyAdded = shoppingItems.filter(
      (shoppingItem) => shoppingItem.product.id === selectedProduct.id,
    )[0]

    const isProductAlreadyAdded = productAlreadyAdded !== undefined

    if (isProductAlreadyAdded) {
      const quantity = productAlreadyAdded.quantity + 1
      productAlreadyAdded.quantity = quantity
      productAlreadyAdded.price = await this.shoppingService.getItemPrice(
        selectedProduct.id,
        quantity,
      )

      this.store.dispatch(new UpdateItemAction(productAlreadyAdded))
    } else {
      const newShoppingItem = {
        id: uuid(),
        quantity: 1,
        price: selectedProduct.price,
        product: selectedProduct,
      } as ShoppingItem

      this.store.dispatch(new AddItemAction(newShoppingItem))
    }
  }

  async getStateAsync(store: Store<AppState>): Promise<ShoppingItem[]> {
    return await store
      .pipe(
        select((store) => store.shopping),
        take(1),
      )
      .toPromise<ShoppingItem[]>()
  }
}
