namespace MyRooms.Shared.Entities
{
    public class BaseEntity
    {
        public List<string> Messages { get; private set; } = new();
        public bool IsValid { get { return !Messages.Any(); } }
        public BaseEntity(int? id)
        {
            Id = id ?? 0;
        }
        public int Id { get; private set; }
        
        public void AddMessage(string message) => Messages.Add(message);
        public void AddMessage(List<string> message) => Messages.AddRange(message);

    }
}
