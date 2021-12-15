import { Inject, Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { Observable } from 'rxjs'
import { catchError } from 'rxjs/operators'
import { handleError } from './handle-error'

@Injectable({ providedIn: 'root' })
export class FetchProductData {
  private url = `${this.baseUrl}api/v1/product`

  constructor(
    private http: HttpClient,
    @Inject('BASE_API_URL') private baseUrl: string
  ) {}

  getAll(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url).pipe(catchError(handleError))
  }
}
