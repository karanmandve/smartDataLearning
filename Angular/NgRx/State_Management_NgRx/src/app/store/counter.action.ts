import { createAction } from "@ngrx/store";



export const increamentCoutner = createAction("Coutner Increament");

export const decreamentCoutner = createAction("Coutner Decreament")

export const resetCounter = createAction("Counter Reset");
