import { createReducer } from "@ngrx/store";
import { Grocery } from "../../models/grocery.model";

const initialState: Grocery[] = [
    { "id": 1, "name": "Banana", "type": "Fruits" },
    { "id": 2, "name": "Chilli", "type": "Vegetable" },
    { "id": 3, "name": "Apple", "type": "Fruits" },
    { "id": 4, "name": "Potato", "type": "Vegetable" },
    { "id": 5, "name": "Lays", "type": "Snacks" },
    { "id": 6, "name": "Red candy", "type": "Candy" },
    { "id": 7, "name": "Tomato", "type": "Vegetable" },
]


export const groceryReduser = createReducer(initialState);