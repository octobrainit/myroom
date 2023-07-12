namespace MyRooms.Shared.Handler
{
    public abstract record BaseInput : IDataInputed
    {
        private static Guid CorrelationId = Guid.NewGuid();

        public Guid GetCorrelationId() => CorrelationId;
    }
}
