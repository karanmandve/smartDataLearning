import { createSelector } from "@ngrx/store";
import { State } from "../reducer/practical.reducer";

export const selectStudentState = (state: any) => state.students;

export const selectAllStudents = createSelector(
  selectStudentState,
  (state: State) => state.allStudents
);

export const selectExamStudents = createSelector(
    selectStudentState,
  (state: State) => state.examStudents
);