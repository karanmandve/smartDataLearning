import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Bucket } from '../Models/bucket.model';
import { Store } from '@ngrx/store';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bucket',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bucket.component.html',
  styleUrl: './bucket.component.scss'
})
export class BucketComponent {

 bucketData?: Observable<Bucket[]>;
  constructor(private store: Store<{ bucketItems: Bucket[] }>) {
    this.bucketData = store.select("bucketItems")
    //console.log(this.groceriesData);

  }
}
