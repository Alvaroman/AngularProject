namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class PicoPlacaExceptionException : AppException
    {
        public PicoPlacaExceptionException() { }
        public PicoPlacaExceptionException(string message) : base(message) { }
        public PicoPlacaExceptionException(string message, System.Exception inner) : base(message, inner) { }
        protected PicoPlacaExceptionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
