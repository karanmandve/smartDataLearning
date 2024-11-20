import { createReducer, on } from "@ngrx/store";
import { Bucket } from "../../Models/bucket.model";
import { BucketAdd } from "../action/bucket.action";


let initialState: Bucket[] = []
export const bucketreducer = createReducer(
    initialState,
    on(BucketAdd, (state, action) => {
        const item=state.find(x=>x.id===action.payload.id)
        if(item){
            return state.map(x=>{
                return x.id===action.payload.id? {...x,quantity:x.quantity+1}:x;
            })
            // let data={
            //     id:action.payload.id,
            //     name:action.payload.name,
            //     quantity:action.payload.quantity+1
            // }
            // return [...state,data]
        }else{
            return [
                ...state,
                action.payload
            ]
        }
    })

)