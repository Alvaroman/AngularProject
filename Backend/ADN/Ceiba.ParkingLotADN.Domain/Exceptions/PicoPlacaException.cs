namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class PicoPlacaException : AppException
    {
        public PicoPlacaException() { }
        public PicoPlacaException(string message) : base(message) { }
        protected PicoPlacaException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
