import { Injectable } from '@angular/core'
import { FetchShoppingItemPriceData } from '../api/fetch-shopping-item-price'
import { ShoppingItemCalculated } from '../contracts/shoppingItemCalculated'

@Injectable({ providedIn: 'root' })
export class ShoppingService {
  constructor(private fetchApi: FetchShoppingItemPriceData) {}

  async getItemPrice(productId: number, quantity: number): Promise<ShoppingItemCalculated> {
    return await this.fetchApi.getItemPrice(productId, quantity)
  }
}
