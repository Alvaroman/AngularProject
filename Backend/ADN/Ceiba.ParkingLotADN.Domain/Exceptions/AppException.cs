namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class AppException : System.Exception
    {
        public AppException() { }
        public AppException(string message) : base(message) { }
        protected AppException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
