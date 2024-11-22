import { createAction, props } from '@ngrx/store';
import { Student } from '../../model/student.model';

export const addStudent = createAction(
  '[Student] Add Student', 
  props<{ student: Student }>()
);

export const removeStudent = createAction(
    '[Student] Remove Student',
    props<{ studentId: number }>()  // Accepts the student ID to remove
  );

// export const addStudentSuccess = createAction(
//   '[Student] Add Student Success', 
//   props<{ student: Student }>()
// );
