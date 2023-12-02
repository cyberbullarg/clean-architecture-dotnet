using SharedKernel;

namespace Domain.Users
{
    public class User : Entity
    {
        public Name Name { get; private set; }
        public bool HasPublicProfile { get; private set; }

        private User(Guid id, Name name) : base(id)
        {
            Name = name;
        }

        public static User Create(Name name)
        {
            User user = new(Guid.NewGuid(), name);

            user.Raise(new UserCreatedDomainEvent(user.Id));

            return user;
        }
    }
}
