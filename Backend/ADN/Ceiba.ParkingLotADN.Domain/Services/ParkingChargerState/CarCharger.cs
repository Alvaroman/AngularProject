namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    public class CarCharger : ChargerState
    {
        protected override decimal HourCharge { get; set; } = 1000;
        protected override decimal DayCharge { get; set; } = 8000;
        protected override bool CylinderRestriction { get; set; }
        protected override decimal CylinderOverCharge { get; set; }
        protected override decimal CylinderLimit { get; set; }
    }
}
