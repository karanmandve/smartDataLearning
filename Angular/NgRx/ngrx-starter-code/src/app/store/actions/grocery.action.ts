import { createAction, createActionGroup, emptyProps, props } from "@ngrx/store";
import { Grocery } from "../../../models/grocery.model";



// export const initGroceries = createAction(
//     "[Grocery] Load Groceries"
// )

// export const completedGroceries = createAction(
//     "[Grocery] Load Groceries Success"
// )

export const groceryAction = createActionGroup({
    source: "Grocery API", // source is giving in square bracket in action name
    events: {
        "Load grocery": emptyProps(),
        "Load grocery Success": props<{payload: Grocery[]}>(),
        "Load grocery Failure": emptyProps(),
    }
})

groceryAction.
