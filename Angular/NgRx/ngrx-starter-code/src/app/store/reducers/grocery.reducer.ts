import { createReducer } from "@ngrx/store";
import { Grocery } from "../../../models/grocery.model";



// const initialState: Grocery[] = [
//     {"id": 1, "name": "Milk", "type": "Dairy"},
//     {"id": 2, "name": "Bread", "type": "Bakery"},
//     {"id": 3, "name": "Eggs", "type": "Dairy"},
//     {"id": 4, "name": "Cake", "type": "Bakery"}
// ]

const initialState: Grocery[] = [
]



export const groceryReducer = createReducer(initialState)