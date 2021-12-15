import { Component, OnInit } from '@angular/core'
import { Observable } from 'rxjs'
import { Store } from '@ngrx/store'

import { ShoppingItem } from '../../contracts/shoppingItem'
import { AppState } from '../../store/app-state'

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
})
export class NavMenuComponent implements OnInit {
  isExpanded = false
  shoppingItems$: Observable<ShoppingItem[]>

  constructor(private store: Store<AppState>) {}

  ngOnInit() {
    this.shoppingItems$ = this.store.select((store) => store.shopping)
  }

  collapse() {
    this.isExpanded = false
  }

  toggle() {
    this.isExpanded = !this.isExpanded
  }
}
