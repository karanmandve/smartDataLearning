import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-structural-directive',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './structural-directive.component.html',
  styleUrl: './structural-directive.component.css'
})
export class StructuralDirectiveComponent {

  cityArray: string [] = ["Nagpur", "Mumbai", "Pune", "Banglore"]
  studentList: any [] = [
    {name:"Karan", age:22},
    {name:"Vedant", age:22},
    {name:"Tejas", age:22},

  ]


}
