import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  private cartCountSubject = new BehaviorSubject<number>(0); // Observable cart count
  cartCount$ = this.cartCountSubject.asObservable();

  incrementCartCount() {
    const currentCount = this.cartCountSubject.value;
    this.cartCountSubject.next(currentCount + 1);
  }

  resetCartCount() {
    this.cartCountSubject.next(0);
  }
  
}
