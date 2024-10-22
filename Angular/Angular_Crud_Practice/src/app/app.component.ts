import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { GetApiComponent } from "./component/get-api/get-api.component";
import { ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, GetApiComponent, RouterLink, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular_Crud_Practice';
}
