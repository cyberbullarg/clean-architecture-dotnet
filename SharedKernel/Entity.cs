namespace SharedKernel
{
    public abstract class Entity
    {
        private readonly List<IDomainEvent> _events = [];

        public Guid Id { get; init; }

        public List<IDomainEvent> DomainEvents => _events.ToList();

        protected Entity(Guid id)
        {
            Id = id;
        }

        protected void Raise(IDomainEvent e) => _events.Add(e);
    }

    public class Result<TValue> : Result
    {
        private readonly TValue _value;

        protected Result(TValue value, bool success, Error error) : base(success, error) => _value = value;

        public TValue Value => IsSuccess ? _value : throw new InvalidOperationException("The value of a failure result can't be accessed");
    }
}
