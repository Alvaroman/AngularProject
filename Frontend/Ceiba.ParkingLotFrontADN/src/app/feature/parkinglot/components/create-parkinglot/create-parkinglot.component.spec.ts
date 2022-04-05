import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppModule } from 'src/app/app.module';

import { CreateParkinglotComponent } from './create-parkinglot.component';

describe('CreateParkinglotComponent', () => {
  let component: CreateParkinglotComponent;
  let fixture: ComponentFixture<CreateParkinglotComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CreateParkinglotComponent],
      imports: [AppModule],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateParkinglotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('must return an invalid form', () => {
    const app = fixture.componentInstance;
    fixture.detectChanges();
    const plate = app.parkinglotForm.controls['plate'];
    plate.setValue('abc-123');
    expect(app.parkinglotForm.invalid).toBeTrue();
  });
  it('must return a valid form', () => {
    const app = fixture.componentInstance;
    fixture.detectChanges();
    const plate = app.parkinglotForm.controls['plate'];
    const cylinder = app.parkinglotForm.controls['cylinder'];
    const vehicleType = app.parkinglotForm.controls['vehicleType'];

    plate.setValue('abc-123');
    cylinder.setValue(16000);
    vehicleType.setValue(1);

    expect(app.parkinglotForm.valid).toBeTrue();
  });
});
