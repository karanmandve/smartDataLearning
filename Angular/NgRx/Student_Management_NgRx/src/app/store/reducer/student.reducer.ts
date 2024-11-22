// src/app/student.reducer.ts
import { createReducer, on } from '@ngrx/store';
import { Student } from '../../model/student.model';
import { addStudent, removeStudent } from '../action/student.action';


export interface StudentState {
  students: Student[];
}

export const initialState: StudentState = {
  students: []
};

export const studentReducer = createReducer(
  initialState,
  on(addStudent, (state, { student }) => ({
    ...state,
    students: [...state.students, student]  // Adds the student to the list
  })),
  on(removeStudent, (state, { studentId }) => ({
    ...state,
    students: state.students.filter(student => student.id !== studentId) // Remove the student by ID
  }))
);
