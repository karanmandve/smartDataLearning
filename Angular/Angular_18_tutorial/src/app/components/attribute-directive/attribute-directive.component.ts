import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-attribute-directive',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './attribute-directive.component.html',
  styleUrl: './attribute-directive.component.css'
})
export class AttributeDirectiveComponent {
  // cityArray: string [] = ["Nagpur", "Mumbai", "Pune", "Banglore"]
  studentList: any [] = [
      {name:"Karan", age:22, isActive: false, mark: 80},
      {name:"Vedant", age:22, isActive: true, mark: 95},
      {name:"Tejas", age:22, isActive: false, mark: 70},
    
    ]
    
    div1BgColor: string = "bg-primary";
    isDiv2Active: boolean = true;
    
    changeBgColor(bgColor: string) {
      this.div1BgColor = bgColor
    }

    changeDiv2(){
      this.isDiv2Active = !this.isDiv2Active;
    }

}
