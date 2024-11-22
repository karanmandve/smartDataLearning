import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Store } from '@ngrx/store';
import { CounterState } from './store/counter.reducer';
import { AppState } from './store/app.state';
import { Observable } from 'rxjs';
import { selectCount, selectCounterState } from './store/counter.selector';
import { decreamentCoutner, increamentCoutner, resetCounter } from './store/counter.action';
import { AsyncPipe } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AsyncPipe],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'State_Management_NgRx';

  counter$: Observable<number> = new Observable<number>;

  constructor(private store: Store<AppState>) {
  this.counter$ = this.store.select(selectCount)
}
  increment() {
    this.store.dispatch(increamentCoutner());
  }

  decrement() {
    this.store.dispatch(decreamentCoutner());
  }

  reset() {
    this.store.dispatch(resetCounter());
  }
}
