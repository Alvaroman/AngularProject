namespace Ceiba.ParkingLotADN.Domain.Exception
{
    [System.Serializable]
    public class AlreadyRegisteredException : AppException
    {
        public AlreadyRegisteredException() { }
        public AlreadyRegisteredException(string message) : base(message) { }
        protected AlreadyRegisteredException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }


    }
}
