import { createFeatureSelector, createSelector } from "@ngrx/store";
import { Grocery } from "../../Models/grocery.model";

export const groceriesList=createFeatureSelector<Grocery[]>("groceries");

export const groceriesListByType=createSelector(
    groceriesList,(state)=>{
        return state.filter(x=>x.type==="Fruits")
    }
)