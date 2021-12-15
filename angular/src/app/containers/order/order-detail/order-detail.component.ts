import { Component, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { Order } from '../../../contracts/order'
import { OrderService } from '../../../services/order.service'

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.css'],
})
export class OrderDetailComponent implements OnInit {
  order = { shoppingItem: [] } as unknown as Order

  constructor(
    private orderService: OrderService,
    private route: ActivatedRoute,
  ) {}

  ngOnInit() {
    this.route.params.subscribe((params) => {
      const id = params.id
      this.getOrder(id)
    })
  }

  getOrder(id: number): void {
    this.orderService.getById(id).subscribe(
      (data) => (this.order = data),
      (error) => {},
    )
  }
}
