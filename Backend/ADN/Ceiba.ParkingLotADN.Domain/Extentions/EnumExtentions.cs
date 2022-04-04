using Ceiba.ParkingLotADN.Domain.Enums;
using Ceiba.ParkingLotADN.Domain.Exception;

namespace Ceiba.ParkingLotADN.Domain.Extentions
{
    public static class EnumExtentions
    {
        private static int CAR_CAPACITY = 6;
        private static int MOTORCYCLE_CAPACITY = 6;

        public static int GetParkingCapacity(this System.Enum value)
        {
            switch (value)
            {
                case VehicleType.Car: return CAR_CAPACITY;
                case VehicleType.Motorcycle: return MOTORCYCLE_CAPACITY;
                default:
                    throw new VehicleNotAllowed("This vehicle type is not considered");
            }
        }
    }
}
