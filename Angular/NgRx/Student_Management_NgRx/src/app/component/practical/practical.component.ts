import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { Student } from '../../model/student.model';
import { Store } from '@ngrx/store';
import { selectAllStudents, selectExamStudents } from '../../store/selector/practical.selector';
import { addStudentToExam, removeStudentFromExam } from '../../store/action/practical.action';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-practical',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './practical.component.html',
  styleUrl: './practical.component.css'
})
export class PracticalComponent {

  allStudents$: Observable<Student[]>;
  examStudents$: Observable<Student[]>;

  constructor(private store: Store) {
    this.allStudents$ = this.store.select(selectAllStudents);
    this.examStudents$ = this.store.select(selectExamStudents);
  }

  ngOnInit() {
    // this.store.dispatch(loadStudents());
  }

  addToExam(student: Student) {
    this.store.dispatch(addStudentToExam({ studentp: student }));
  }

  removeFromExam() {
    this.store.dispatch(removeStudentFromExam());
  }
}
