import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs'
import { Store } from '@ngrx/store'
import { v4 as uuid } from 'uuid'

import { AppState } from '../../store/app-state'
import { ProductService } from '../../services/product.service'
import { ShoppingItem } from 'src/app/contracts/shoppingItem'
import { AddItemAction } from '../../store/shopping.actions'

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  shoppingItems$: Observable<ShoppingItem[]>
  products: Product[]

  constructor(
    private store: Store<AppState>,
    private productService: ProductService
  ) {}

  ngOnInit() {
    this.productService
      .getAll()
      .subscribe((result) => (this.products = result))
  }

  addToCart(selectedProduct: Product): void {
    const newShoppingItem = {
      id: uuid(),
      quantity: 1,
      price: selectedProduct.price,
      product: selectedProduct,
    } as ShoppingItem

    this.store.dispatch(new AddItemAction(newShoppingItem))
  }
}
