import { Inject, Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { catchError, filter, first } from 'rxjs/operators'
import { handleError } from './handle-error'
import { ShoppingItemCalculated } from '../contracts/shoppingItemCalculated'

@Injectable({ providedIn: 'root' })
export class FetchShoppingItemPriceData {
  private url = `${this.baseUrl}api/v1/shopping`

  constructor(
    private http: HttpClient,
    @Inject('BASE_API_URL') private baseUrl: string,
  ) {}

  async getItemPrice(
    productId: number,
    quantity: number,
  ): Promise<ShoppingItemCalculated> {
    return await this.http
      .get<ShoppingItemCalculated>(`${this.url}/${productId}/${quantity}`)
      .pipe(
        catchError(handleError),
        filter((value) => value !== null && value !== undefined),
        first(),
      )
      .toPromise()
  }
}
