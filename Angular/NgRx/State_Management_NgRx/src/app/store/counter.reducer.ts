import { createReducer, on } from "@ngrx/store"
import { decreamentCoutner, increamentCoutner, resetCounter } from "./counter.action"



export interface CounterState {
    count: number
}

export const initialCount : CounterState = {
    count: 0
}

export const reducer = createReducer(
    initialCount,
    on(increamentCoutner, state => ({...state, count: state.count + 1})),
    on(decreamentCoutner, state => ({...state, count: state.count - 1})),
    on(resetCounter, state => ({...state, count: 0}))

)