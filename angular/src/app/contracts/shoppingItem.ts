import { Product } from './product'

export interface ShoppingItem {
  id: string
  quantity: number
  price: number
  product: Product
  promotionApplied: boolean
}
