namespace MyRooms.Shared.Handler
{
    public class HandlerOutput
    {
        public object? Output { get; private set; }
        public List<string> Messages { get; private set; } = new();
        public bool IsValid => !Messages.Any();

        public HandlerOutput(object? output = null)
        {
            Output = output;
        }

        public void AddMessage(string message) => Messages.Add(message);
        public void AddMessage(List<string> message) => Messages.AddRange(message);
        public void AddResult(object data) => Output = data;    
    }
}
