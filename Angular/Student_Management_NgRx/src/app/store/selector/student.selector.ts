// src/app/student.selectors.ts
import { createFeatureSelector, createSelector } from '@ngrx/store';
import { StudentState } from '../reducer/student.reducer';


export const selectStudentState = createFeatureSelector<StudentState>('student');

export const selectAllStudents = createSelector(
  selectStudentState,
  (state: StudentState) => state.students
);

