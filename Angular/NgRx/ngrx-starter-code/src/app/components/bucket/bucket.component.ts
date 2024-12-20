import { Component } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Bucket } from '../../../models/bucket.model';
import { CommonModule } from '@angular/common';
import { Store } from '@ngrx/store';
import { Grocery } from '../../../models/grocery.model';


@Component({
  selector: 'app-bucket',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bucket.component.html',
  styleUrl: './bucket.component.css'
})
export class BucketComponent {

   myBucket$?:Observable<Bucket[]>; 

  //  oberservable: Observable<number>;
   
   constructor(private store: Store<{bucket: Bucket[]}>) {
    this.myBucket$ = store.select('bucket');
   }

}
