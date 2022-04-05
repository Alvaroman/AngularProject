import { Component, OnInit } from '@angular/core';
import { Parkinglot } from '../../shared/model/parkinglot';
import { ParkinglotService } from '../../shared/service/parkintlot.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styles: [],
})
export class DashboardComponent implements OnInit {
  single: any[];
  multi: any[];
  viewLine = [1200, 500];
  viewPie = [600, 305];
  carDayAverage = 0;
  motorcycleDayAverage = 0;
  colorScheme = {
    domain: ['#770A0A', '#40770A'],
  };

  // options
  gradient = true;
  showLegend = true;
  showLabels = true;
  isDoughnut = false;

  legend = true;
  animations = true;
  xAxis = true;
  yAxis = true;
  showYAxisLabel = true;
  showXAxisLabel = true;
  xAxisLabel = 'Date';
  yAxisLabel = 'Quantity';
  timeline = true;

  public parkingLots: Parkinglot[] = [];

  constructor(protected HomeService: ParkinglotService) {}

  ngOnInit(): void {
    this.HomeService.get().subscribe((resp) => {
      this.parkingLots = resp;

      this.setCarData();
      this.setMotorcycleData();
      let myResults = this.multi;
      let mySingle = this.single;
      Object.assign(this, { myResults });
      Object.assign(this, { mySingle });
    });
  }
  setCarData() {
    const CAR = 1;

    let carsSeries: any[] = [];
    let carDates = new Set(
      this.parkingLots
        .sort((a, b) => {
          return new Date(a.startedAt) > new Date(b.startedAt) ? 1 : -1;
        })
        .filter((x) => x.vehicleType === CAR)
        .map((x) => new Date(x.startedAt).toLocaleDateString())
    );
    carDates.forEach((date) => {
      let count = this.parkingLots.filter(
        (x) =>
          x.vehicleType === CAR &&
          new Date(x.startedAt).toLocaleDateString() === date
      ).length;
      carsSeries.push({
        name: date,
        value: count,
      });
      this.carDayAverage += count;
    });
    this.carDayAverage = parseFloat(
      (this.carDayAverage / carDates.size).toFixed(2)
    );
    if (this.multi) {
      this.multi.push({ name: 'Cars', series: carsSeries });
    } else {
      this.multi = [{ name: 'Cars', series: carsSeries }];
    }
    if (this.single) {
      this.single.push({
        name: 'Cars',
        value: this.parkingLots.filter(
          (vehicle) => vehicle.status && vehicle.vehicleType === CAR
        ).length,
      });
    } else {
      this.single = [
        {
          name: 'Cars',
          value: this.parkingLots.filter(
            (vehicle) => vehicle.status && vehicle.vehicleType === CAR
          ).length,
        },
      ];
    }
  }
  setMotorcycleData() {
    const MOTORCYCLE = 2;
    let motorcycleSeries: any[] = [];
    let motorcycleDates = new Set(
      this.parkingLots
        .sort((a, b) => {
          return new Date(a.startedAt) > new Date(b.startedAt) ? 1 : -1;
        })
        .filter((x) => x.vehicleType === MOTORCYCLE)
        .map((x) => new Date(x.startedAt).toLocaleDateString())
    );
    motorcycleDates.forEach((date) => {
      let count = this.parkingLots.filter(
        (x) =>
          x.vehicleType === MOTORCYCLE &&
          new Date(x.startedAt).toLocaleDateString() === date
      ).length;
      motorcycleSeries.push({
        name: date,
        value: count,
      });
      this.motorcycleDayAverage += count;
    });

    this.motorcycleDayAverage = parseFloat(
      (this.motorcycleDayAverage / motorcycleDates.size).toFixed(2)
    );

    this.multi.push({ name: 'Motorcycles', series: motorcycleSeries });
    this.single.push({
      name: 'Motorcycles',
      value: this.parkingLots.filter(
        (vehicle) => vehicle.status && vehicle.vehicleType === MOTORCYCLE
      ).length,
    });
  }
}
