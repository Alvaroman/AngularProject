import { Component, OnInit } from '@angular/core';
import { Parkinglot } from '../../shared/model/parkinglot';
import { ParkinglotService } from '../../shared/service/parkintlot.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

const PLATE_REQUIRED_LENGTH = 7;
@Component({
  selector: 'app-create-parkinglot',
  templateUrl: './create-parkinglot.component.html',
  styleUrls: ['./create-parkinglot.component.css'],
})
export class CreateParkinglotComponent implements OnInit {
  parkingLots: Parkinglot[];
  parkinglotForm: FormGroup;
  constructor(
    protected service: ParkinglotService,
    protected toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getParkingLotData();
    this.buildParkingLotForm();
  }
  getParkingLotData() {
    this.service.get().subscribe((resp) => {
      this.parkingLots = resp
        .filter((vehicle) => vehicle.status)
        .sort((a, b) => {
          return new Date(a.startedAt) < new Date(b.startedAt) ? 1 : -1;
        });
    });
  }
  getStartedAtDatePart(id: string) {
    let parkingLotValue = this.parkingLots.find((x) => x.id === id);
    return parkingLotValue !== undefined
      ? new Date(parkingLotValue?.startedAt).toLocaleTimeString()
      : '';
  }
  getStartedAtHourPart(id: string) {
    let parkingLotValue = this.parkingLots.find((x) => x.id === id);
    return parkingLotValue !== undefined
      ? new Date(parkingLotValue?.startedAt).toLocaleDateString()
      : '';
  }
  onSubmit() {
    this.service.create(this.parkinglotForm.value).subscribe(
      () => {
        this.toastr.success('Vehicle registered correctly!');
        this.buildParkingLotForm();
        this.getParkingLotData();
      },
      (err) => {
        this.toastr.error(err.error.message);
      }
    );
  }
  onRelease(id: string) {
    this.service.release(id).subscribe(
      (resp) => {
        this.getParkingLotData();
        this.toastr.success(
          `Vehicle released correctly. The charge is '${resp}'.`,
          'Vehicle released',
          {
            timeOut: 10000,
            progressBar: true,
          }
        );
      },
      (err) => {
        this.toastr.error(err.error.message);
      }
    );
  }
  onCostRequest(id: string) {
    this.service.getCost(id).subscribe(
      (resp) => {
        this.getParkingLotData();
        this.toastr.info(`The charge is: '${resp}'.`, 'Charge request', {
          timeOut: 10000,
          progressBar: true,
        });
      },
      (err) => {
        this.toastr.error(err.error.message);
      }
    );
  }
  private buildParkingLotForm() {
    this.parkinglotForm = new FormGroup({
      id: new FormControl(''),
      cylinder: new FormControl('', [Validators.required]),
      plate: new FormControl('', [
        Validators.required,
        Validators.maxLength(PLATE_REQUIRED_LENGTH),
        Validators.pattern(`^\\w{3}-\\d{2}\\w$`),
      ]),
      vehicleType: new FormControl('', [Validators.required]),
    });
  }
}
