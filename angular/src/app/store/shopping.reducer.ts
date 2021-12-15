import { ShoppingActionTypes, ShoppingAction } from './shopping.actions'
import { ShoppingItem } from '../contracts/shoppingItem'

const initialState: ShoppingItem[] = []

export function ShoppingReducer(
  state: ShoppingItem[] = initialState,
  action: ShoppingAction
) {
  switch (action.type) {
    case ShoppingActionTypes.ADD_ITEM: {
      if (state.length > 0) {
        const productAlreadyAdded =
          state.filter(
            (shoppingItem) =>
              shoppingItem.product.id === action.payload.product.id
          ).length > 0

        if (productAlreadyAdded) {
          const addingProductToCurrentShoppingList = state.map(
            (shoppingItem) => {
              if (shoppingItem.product.id === action.payload.product.id) {
                const quantity = shoppingItem.quantity + 1
                return {
                  id: shoppingItem.id,
                  quantity,
                  price: shoppingItem.product.price * Number(quantity),
                  product: shoppingItem.product,
                } as ShoppingItem
              }
              return shoppingItem
            }
          )
          return [...addingProductToCurrentShoppingList]
        }
      }

      return [...state, action.payload]
    }

    case ShoppingActionTypes.DELETE_ITEM:
      return state.filter((item) => item.id !== action.payload)

    case ShoppingActionTypes.DELETE_All_ITEM:
      return []

    case ShoppingActionTypes.UPDATE_ITEM:
      state.map((newsItem) => {
        if (newsItem.id === action.payload.id) {
          return [newsItem, action.payload]
        }
      })
      return state

    default:
      return state
  }
}
