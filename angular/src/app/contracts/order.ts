import { ShoppingItem } from './shoppingItem'

export class Order {
  id: string
  date: Date
  total: number
  shoppingItems: ShoppingItem[]

  constructor() {
    this.id = null
    this.date = null
    this.total = null
    this.shoppingItems = []
  }
}
