import { Inject, Injectable } from '@angular/core'
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { Observable } from 'rxjs'
import { catchError } from 'rxjs/operators'
import { Order } from '../contracts/order'
import { handleError } from './handle-error'

@Injectable({ providedIn: 'root' })
export class OrderOperations {
  private url = `${this.baseUrl}api/v1/order`
  private headers = new HttpHeaders({ 'Content-Type': 'application/json' })
  private options = { headers: this.headers }

  constructor(
    private http: HttpClient,
    @Inject('BASE_API_URL') private baseUrl: string,
  ) {}

  getAll(): Observable<Order[]> {
    return this.http.get<Order[]>(this.url).pipe(catchError(handleError))
  }

  add(order: Order): Observable<Order> {
    return this.http
      .post<Order>(this.url, order, this.options)
      .pipe(catchError(handleError))
  }

  getById(id: number): Observable<Order> {
    const url = `${this.url}/${id}`
    return this.http.get<Order>(url).pipe(catchError(handleError))
  }
}
