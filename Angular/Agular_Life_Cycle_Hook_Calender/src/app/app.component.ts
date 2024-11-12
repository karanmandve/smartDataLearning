import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MatDatepickerModule, MatNativeDateModule, MatCardModule, MatFormFieldModule,MatInputModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Agular_Life_Cycle_Hook_Calender';

  dateChanged(date: Date) {
    console.log('Selected date:', date);
  }

  selectedDate: Date | null = null;
  hoverMessage: string | null = null;

  
  specialDates: any = {
    '2024-11-15': 'Special Event on this day!',
    '2024-12-25': 'Christmas Day!',
  };

  // Handle the hover event on a date
  onDateHover(event: MouseEvent): void {
    const target = event.target as HTMLElement;
    const date = target?.textContent?.trim();

    if (date && this.specialDates[`2024-11-${date}`]) {
      this.hoverMessage = this.specialDates[`2024-11-${date}`];
    } else {
      this.hoverMessage = null;
    }
  }

  // Handle the date selection via 'selectedChange' event
  onDateSelected(date: Date): void {
    this.selectedDate = date;
    console.log('Date selected:', date);
  }

  // Handle month selection
  onMonthSelected(month: number): void {
    console.log('Month selected:', month);
  }

  // Handle year selection
  onYearSelected(year: number): void {
    console.log('Year selected:', year);
  }
}
