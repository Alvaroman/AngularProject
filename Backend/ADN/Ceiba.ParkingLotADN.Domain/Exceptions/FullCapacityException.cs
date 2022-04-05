namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class FullCapacityException : AppException
    {
        public FullCapacityException() { }
        public FullCapacityException(string message) : base(message) { }
        protected FullCapacityException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
