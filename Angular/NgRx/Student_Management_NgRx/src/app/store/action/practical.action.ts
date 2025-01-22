// src/app/store/student.actions.ts
import { createAction, props } from '@ngrx/store';
import { Student } from '../../model/student.model';

export const addStudentToExam = createAction('[Student] Add Student to Exam', props<{ studentp: Student }>());
export const removeStudentFromExam = createAction('[Student] Remove Student from Exam', props<{}>);

