import { Injectable } from '@angular/core'
import { Observable } from 'rxjs'
import { FetchProductData } from '../api/fetch-products'
import { Product } from '../contracts/product'

@Injectable({ providedIn: 'root' })
export class ProductService {
  constructor(private fetchApi: FetchProductData) {}

  getAll(): Observable<Product[]> {
    return this.fetchApi.getAll()
  }
}
