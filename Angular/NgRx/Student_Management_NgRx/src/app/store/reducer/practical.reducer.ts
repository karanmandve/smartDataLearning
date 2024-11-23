import { createReducer, on } from '@ngrx/store';
import { Student } from '../../model/student.model';
import { addStudentToExam, removeStudentFromExam } from '../action/practical.action';

export interface State {
  allStudents: Student[];
  examStudents: Student[];
}

export const initialState: State = {
  allStudents: [
    { id: 1, name: 'Student 1' },
    { id: 2, name: 'Student 2' },
    { id: 3, name: 'Student 3' },
    { id: 4, name: 'Student 4' },
    { id: 5, name: 'Student 5' },
    { id: 6, name: 'Student 6' },
    { id: 7, name: 'Student 7' },
    { id: 8, name: 'Student 8' },
    { id: 9, name: 'Student 9' },
    { id: 10, name: 'Student 10' },
    { id: 11, name: 'Student 11' },
    { id: 12, name: 'Student 12' },
    { id: 13, name: 'Student 13' },
    { id: 14, name: 'Student 14' },
    { id: 15, name: 'Student 15' },
    { id: 16, name: 'Student 16' },
    { id: 17, name: 'Student 17' },
    { id: 18, name: 'Student 18' },
    { id: 19, name: 'Student 19' },
    { id: 20, name: 'Student 20' }
  ],
  examStudents: []
};

export const studentpReducer = createReducer(
  initialState,
  on(addStudentToExam, (state, { studentp }) => ({
    ...state,
    allStudents: state.allStudents.filter(s => s.id !== studentp.id),
    examStudents: [...state.examStudents, studentp]
  })),
  on(removeStudentFromExam, (state, {}) => {
    if (state.examStudents.length === 0) {
      return state; // No students to remove from the exam
    }

    // const studentToRemove = state.examStudents[0]; // Remove the first student from the exam list
    // const newExamStudents = state.examStudents.slice(1); // Remove the student from the exam list
    const newExamStudents = state.examStudents.slice(1); // Remove the student from the exam list

    if (state.allStudents.length === 0) {
      return {
        ...state,
        examStudents: newExamStudents // Just remove the student from the exam list
      };
    }

    const newStudent = state.allStudents[0]; // Add the first student from the available list to the practical exam

    return {
      ...state,
      allStudents: state.allStudents.slice(1), // Remove the student from the available list
      examStudents: [...newExamStudents, newStudent] // Add the new student to the exam list
    };
  })
);