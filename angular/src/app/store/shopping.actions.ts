import { Action } from '@ngrx/store'
import { ShoppingItem } from '../contracts/shoppingItem'

export enum ShoppingActionTypes {
  ADD_ITEM = '[SHOPPING] Add Item',
  DELETE_ITEM = '[SHOPPING] Delete Item',
  DELETE_All_ITEM = '[SHOPPING] Delete All Item',
  UPDATE_ITEM = '[SHOPPING] Update Item',
}

export class AddItemAction implements Action {
  readonly type = ShoppingActionTypes.ADD_ITEM
  constructor(public payload: ShoppingItem) {}
}

export class DeleteItemAction implements Action {
  readonly type = ShoppingActionTypes.DELETE_ITEM
  constructor(public payload: string) {}
}

export class DeleteAllItemAction implements Action {
  readonly type = ShoppingActionTypes.DELETE_All_ITEM
  constructor() {}
}

export class UpdateItemAction implements Action {
  readonly type = ShoppingActionTypes.UPDATE_ITEM
  constructor(public payload: ShoppingItem) {}
}

export type ShoppingAction =
  | AddItemAction
  | DeleteItemAction
  | DeleteAllItemAction
  | UpdateItemAction
