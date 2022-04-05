namespace Ceiba.ParkingLotADN.Domain.Services.ParkingChargerState
{
    public abstract class ChargerState
    {
        const int DAY_DIVIDOR = 9;
        const int HOUR_PER_DAY = 24;
        protected abstract decimal HourCharge { get; set; }
        protected abstract decimal DayCharge { get; set; }
        protected abstract bool CylinderRestriction { get; set; }
        protected abstract decimal CylinderOverCharge { get; set; }
        protected abstract decimal CylinderLimit { get; set; }
        /// <summary>
        /// Calculate the cost to pay.
        /// </summary>
        /// <param name="spentHours">Spent hours as decimal.</param>
        /// <param name="cylinder">Cylinder.</param>
        /// <returns><see cref="decimal"/></returns>
        public virtual decimal Calculate(int spentHours, int cylinder)
        {
            decimal charge = 0;
            if (spentHours < DAY_DIVIDOR)
            {
                charge = spentHours * HourCharge;
            }
            else
            {
                do
                {
                    charge += DayCharge;
                    spentHours -= HOUR_PER_DAY;
                } while (spentHours / HOUR_PER_DAY >= 1);
                if (spentHours > 0)
                {
                    charge += spentHours * HourCharge;
                }
            }
            if (CylinderRestriction && cylinder >= CylinderLimit)
            {
                charge += CylinderOverCharge;
            }
            return charge;
        }
    }
}
