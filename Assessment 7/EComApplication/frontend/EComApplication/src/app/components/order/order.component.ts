import { Component, inject } from '@angular/core';
import { OrderService } from '../../services/order/order.service';
import { CommonModule, DatePipe } from '@angular/common';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [DatePipe, CommonModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  orders: any[] = [];
  userDetails = JSON.parse(localStorage.getItem('userDetails') || '{}');

  orderService = inject(OrderService);

  ngOnInit(): void {
    
    this.getOrder();
    // this.orderService.getAllOrderByUserId(userId).subscribe((data: any[]) => {
    //   this.orders = data; 
    // });
  }


  getOrder(){

    this.orderService.getAllOrderByUserId(this.userDetails.id).subscribe({
      next: (data: any) => {
        this.orders = data;  
      },
      error: (error: any) => {
        console.error('Error fetching orders:', error);
      }
    })
  }


  downloadReceipt(invoicePdfLink: string): void {
    const link = document.createElement('a');
    link.href = invoicePdfLink;
    link.click();
  }
}
