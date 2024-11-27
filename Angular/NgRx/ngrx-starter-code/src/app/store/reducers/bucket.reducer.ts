import { createReducer, on } from '@ngrx/store';
import { Bucket } from '../../../models/bucket.model';
import { addToBucket, removeFromBucket } from '../actions/bucket.action';

const initilaState: Bucket[] = [];

export const bucketReducer = createReducer(
  initilaState,
  on(addToBucket, (state, action) => {
    const data = state.find((item) => item.id === action.payload.id);

    if (data) {
      return state.map((item) => {
        return item.id === action.payload.id
          ? { ...item, quantity: item.quantity + action.payload.quantity }
          : item;
      });
    }

    return [...state, action.payload];
  }),

  on(removeFromBucket, (state, action) => {
    const existingItem = state.find((item) => item.id === action.payload.id);
    if (existingItem && existingItem?.quantity > 1) {
      return state.map((item) =>
        item.id === action.payload.id
          ? { ...item, quantity: item.quantity - 1 }
          : item
      );
    }
    return state.filter((item) => item.id !== action.payload.id);
  })
);
