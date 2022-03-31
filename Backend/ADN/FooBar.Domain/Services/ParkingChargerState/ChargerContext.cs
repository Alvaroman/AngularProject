﻿using FooBar.Domain.Enums;
using FooBar.Domain.Exception;

namespace FooBar.Domain.Services.ParkingChargerState
{
    [DomainService]
    public class ChargerContext
    {
        private ChargerState State { get; set; } = default!;
        public decimal CalculateCharge(int spentHours, int cylinder, VehicleType vehicleType)
        {
            this.State = vehicleType switch
            {
                VehicleType.Car => new CarCharger(),
                VehicleType.Motorcycle => new MotorcycleCharger(),
                _ => throw new VehicleNotAllowed("This vehicle type is not considered")
            };
            return this.State.Calculate(spentHours, cylinder);
        }
    }
}
    