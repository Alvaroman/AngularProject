import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Parkinglot } from '../model/parkinglot';
import { HttpService } from '@core/services/http.service';

@Injectable()
export class ParkinglotService {
  constructor(protected http: HttpService) {}

  public get() {
    return this.http.doGet<Parkinglot[]>(`${environment.endpoint}/parking`);
  }
  public getCost(id: string) {
    return this.http.doGet<number>(
      `${environment.endpoint}/parking/${id}/cost`
    );
  }
  public create(parkingLot: Parkinglot) {
    return this.http.doPost<Parkinglot, any>(
      `${environment.endpoint}/parking`,
      parkingLot
    );
  }
  public release(id: string) {
    return this.http.doPut<Parkinglot, any>(
      `${environment.endpoint}/parking/${id}/release`,
      null
    );
  }
}
