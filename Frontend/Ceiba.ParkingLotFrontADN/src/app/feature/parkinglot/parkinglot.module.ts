import { NgModule } from '@angular/core';
import { ParkinglotService } from './shared/service/parkintlot.service';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { CreateParkinglotComponent } from './components/create-parkinglot/create-parkinglot.component';
import { ParkingLotRoutingModule } from './parkinglot-routing.module';
import { SharedModule } from '@shared/shared.module';
import { NgxChartsModule } from '@swimlane/ngx-charts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [DashboardComponent, CreateParkinglotComponent],
  imports: [
    ParkingLotRoutingModule,
    SharedModule,
    NgxChartsModule,
    BrowserAnimationsModule,
    FormsModule,
  ],
  providers: [ParkinglotService],
})
export class ParkingLotModule {}
