namespace Ceiba.ParkingLotADN.Domain.Services.ParkingPicoPlacaState
{
    public class CarPicoPlaca : PicoPlacaState
    {
        public override bool PicoPlacaValidator(string plate)
        {
            if (DateTime.Now.Hour > INITIAL_HOUR && DateTime.Now.Hour < FINAL_HOUR)
            {
                int[] currentRestrictions = { PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 0], PICO_Y_PLACA_DAYS[(int)DateTime.Today.DayOfWeek, 1] };
                int numberToValidate = Convert.ToInt16(plate.Substring(plate.Length - 1));
                return !currentRestrictions.Contains(numberToValidate);
            }
            return true;
        }
    }
}
