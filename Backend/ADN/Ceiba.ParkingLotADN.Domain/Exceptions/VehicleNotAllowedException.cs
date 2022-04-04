namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class VehicleNotAllowedException : AppException
    {
        public VehicleNotAllowedException() { }
        public VehicleNotAllowedException(string message) : base(message) { }
        public VehicleNotAllowedException(string message, System.Exception inner) : base(message, inner) { }
        protected VehicleNotAllowedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
