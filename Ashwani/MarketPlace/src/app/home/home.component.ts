import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common'
import { Grocery } from '../models/grocery.model';
import { Bucket } from '../Models/bucket.model';
import { BucketAdd, removeFromBucket } from '../store/action/bucket.action';
import { groceriesList, groceriesListByType } from '../store/selector/grocery.selector';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

  groceriesData?: Observable<Grocery[]>;
  constructor(private store: Store<{ groceries: Grocery[] }>) {
    this.groceriesData = store.select(groceriesListByType);
    //this.groceriesData=store.select(groceriesListByType);
    //console.log(this.groceriesData);

  }
  AddItem(item: Grocery) {
    let loads:Bucket = {
      "id": item.id,
      "name": item.name,
      "quantity": 1
    }
    this.store.dispatch(BucketAdd({payload:loads}))

  }
  SubItem(item: Grocery) {
    let payload:Bucket = {
      "id": item.id,
      "name": item.name,
      "quantity": 1
    }
    this.store.dispatch(removeFromBucket({payload}))
  }
}
