import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Grocery } from "../../models/grocery.model";

export const groceriesList=createFeatureSelector<Grocery[]>("groceries");

export const groceriesListByType=createSelector(
    groceriesList,(state)=>{
        return state.filter(x=>x.type==="Fruits")
    }
)