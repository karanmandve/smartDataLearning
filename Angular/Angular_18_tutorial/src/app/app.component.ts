import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { StructuralDirectiveComponent } from "./components/structural-directive/structural-directive.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular_18_tutorial';
}
