import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { HomeComponent } from "./home/home.component";
import { BucketComponent } from "./bucket/bucket.component";
import { OperatersComponent } from "./component/operaters/operaters.component"


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HomeComponent, BucketComponent, OperatersComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'MarketPlace';
  constructor(private router:Router){

  }
  gotoProductPage(){
    let id=2
    this.router.navigate([`/product/:${id}`])
  }
}
