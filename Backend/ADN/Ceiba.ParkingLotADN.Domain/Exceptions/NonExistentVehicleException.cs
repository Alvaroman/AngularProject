namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class NonExistentVehicleException : AppException
    {
        public NonExistentVehicleException() { }
        public NonExistentVehicleException(string message) : base(message) { }
        public NonExistentVehicleException(string message, System.Exception inner) : base(message, inner) { }
        protected NonExistentVehicleException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
