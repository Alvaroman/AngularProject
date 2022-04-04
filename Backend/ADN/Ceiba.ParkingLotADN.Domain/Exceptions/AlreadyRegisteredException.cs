namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class AlreadyRegisteredException : AppException
    {
        public AlreadyRegisteredException() { }
        public AlreadyRegisteredException(string message) : base(message) { }
        public AlreadyRegisteredException(string message, System.Exception inner) : base(message, inner) { }
        protected AlreadyRegisteredException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }
}
