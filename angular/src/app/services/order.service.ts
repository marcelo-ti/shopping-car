import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { OrderOperations } from '../api/order-operations'
import { Order } from '../contracts/order'

@Injectable({ providedIn: 'root' })
export class OrderService {
  constructor(private orderApi: OrderOperations) {}

  getAll(): Observable<Order[]> {
    return this.orderApi.getAll()
  }

  getById(id: number): Observable<Order> {
    return this.orderApi.getById(id)
  }

  add(order: Order): Observable<Order> {
    return this.orderApi.add(order)
  }
}
