import { createAction, props } from "@ngrx/store";
import { Bucket } from "../../Models/bucket.model";



export const BucketAdd = createAction(
    '[Bucket] Add Item',
    props<{payload: Bucket|any}>()
)   

export const removeFromBucket= createAction(
    '[Bucket] remove Item',
    props<{payload: Bucket|any}>()
)