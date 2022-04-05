import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppModule } from 'src/app/app.module';

import { DashboardComponent } from './dashboard.component';

describe('DashboardComponent', () => {
  let component: DashboardComponent;
  let fixture: ComponentFixture<DashboardComponent>;
  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DashboardComponent],
      imports: [AppModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
  it('should be equals to chart object 1', () => {
    const app = fixture.componentInstance;
    fixture.detectChanges();
    let thisDay = new Date();
    app.parkingLots = [
      {
        id: '',
        vehicleType: 1,
        cylinder: 16000,
        finishedAt: thisDay,
        plate: 'abc-123',
        startedAt: thisDay,
        status: true,
      },
      {
        id: '',
        vehicleType: 2,
        cylinder: 10000,
        finishedAt: thisDay,
        plate: 'abc-1dd',
        startedAt: thisDay,
        status: true,
      },
    ];
    app.setCarData();
    app.setMotorcycleData();
    const seriesObject = [
      {
        name: 'Cars',
        series: [{ name: thisDay.toLocaleDateString(), value: 1 }],
      },
      {
        name: 'Motorcycles',
        series: [{ name: thisDay.toLocaleDateString(), value: 1 }],
      },
    ];
    expect(app.multi).toEqual(seriesObject);
  });
  it('should be equals to chart object 2', () => {
    const app = fixture.componentInstance;
    fixture.detectChanges();
    let thisDay = new Date();
    app.parkingLots = [
      {
        id: '',
        vehicleType: 1,
        cylinder: 16000,
        finishedAt: thisDay,
        plate: 'abc-123',
        startedAt: thisDay,
        status: true,
      },
      {
        id: '',
        vehicleType: 2,
        cylinder: 10000,
        finishedAt: thisDay,
        plate: 'abc-1dd',
        startedAt: thisDay,
        status: true,
      },
    ];
    app.setCarData();
    app.setMotorcycleData();
    const seriesObject = [
      {
        name: 'Cars',
        value: 1,
      },
      {
        name: 'Motorcycles',
        value: 1,
      },
    ];
    expect(app.single).toEqual(seriesObject);
  });
});
