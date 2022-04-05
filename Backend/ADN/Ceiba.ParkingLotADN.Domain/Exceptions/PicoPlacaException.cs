namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class PicoPlacaException : AppException
    {
        public PicoPlacaException() { }
        public PicoPlacaException(string message) : base(message) { }
        public PicoPlacaException(string message, System.Exception inner) : base(message, inner) { }
        protected PicoPlacaException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
