import { Component } from '@angular/core';
import { ReactiveComponent } from '../form/reactive/reactive.component';
import { TemplateComponent } from '../form/template/template.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-master',
  standalone: true,
  imports: [ReactiveComponent, TemplateComponent, CommonModule],
  templateUrl: './master.component.html',
  styleUrl: './master.component.css'
})
export class MasterComponent {
  currentComponent: string = "";

  changeComponent(currComponent: string) {
    this.currentComponent = currComponent;
  }
}
