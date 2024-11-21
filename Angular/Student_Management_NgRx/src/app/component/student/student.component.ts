import { Component } from '@angular/core';
import { Student } from '../../model/student.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { selectAllStudents } from '../../store/selector/student.selector';
import { addStudent, removeStudent } from '../../store/action/student.action';
import { AsyncPipe, CommonModule } from '@angular/common';
import { StudentState } from '../../store/reducer/student.reducer';

@Component({
  selector: 'app-student',
  standalone: true,
  imports: [CommonModule, AsyncPipe, ReactiveFormsModule],
  templateUrl: './student.component.html',
  styleUrl: './student.component.css'
})
export class StudentComponent {

  students$: Observable<Student[]>;
  studentForm: FormGroup; // Declare form group

  constructor(private store: Store<StudentState>, private fb: FormBuilder) {
    this.students$ = this.store.select(selectAllStudents);
    this.studentForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]], // Name validation
      age: ['', [Validators.required, Validators.min(18), Validators.max(100)]], // Age validation
    });
  }

  ngOnInit(): void {
    // Initialize any logic here (no need for loading in this case)
  }

  onSubmit(): void {
    if (this.studentForm.valid) {
      const newStudent: Student = {
        id: Date.now(),  // Generate unique ID based on timestamp
        name: this.studentForm.value.name,  // Get name from form
        age: this.studentForm.value.age,    // Get age from form
      };

      // Dispatch action to add student
      console.log(newStudent)
      this.store.dispatch(addStudent({ student: newStudent }));

      // Reset form after submission
      this.studentForm.reset();
    }
  }

  onRemoveStudent(studentId: number): void {
    this.store.dispatch(removeStudent({ studentId }));
  }


}
