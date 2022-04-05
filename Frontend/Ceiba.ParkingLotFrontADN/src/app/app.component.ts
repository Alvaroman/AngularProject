import { Component } from '@angular/core';
import { MenuItem } from '@core/modelo/menu-item';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styles: [],
})
export class AppComponent {
  title = 'app-base';
  public companies: MenuItem[] = [
    { url: '/parkinglot', nombre: 'Dashboard' },
    { url: '/create', nombre: 'Registered Vehicles' },
    { url: '/parkinglot', nombre: 'About' },
  ];
}
