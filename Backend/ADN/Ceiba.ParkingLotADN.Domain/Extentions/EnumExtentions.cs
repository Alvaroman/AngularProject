using Ceiba.ParkingLotADN.Domain.Enums;
using Ceiba.ParkingLotADN.Domain.Exception;

namespace Ceiba.ParkingLotADN.Domain.Extentions
{
    public static class EnumExtentions
    {
        private static int CAR_CAPACITY = 20;
        private static int MOTORCYCLE_CAPACITY = 10;

        public static int GetParkingCapacity(this System.Enum value)
        {
            switch (value)
            {
                case VehicleType.Car: return CAR_CAPACITY;
                default: return MOTORCYCLE_CAPACITY;
            }
        }
    }
}
