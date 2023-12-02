using SharedKernel;

namespace Domain.Followers
{
    public sealed class Follower : Entity
    {
        public Guid UserId { get; private set; }
        public Guid FollowerId { get; private set; }
        public DateTime CreatedAt { get; private set; }

        internal Follower(Guid userId, Guid followerId, DateTime createdAt)
        {
            UserId = userId;
            FollowerId = followerId;
            CreatedAt = createdAt;
        }

        public static Follower Create(Guid userId, Guid followerId, DateTime createdAt)
        {
            Follower follower = new(userId, followerId, createdAt); 

            follower.Raise(new FollowerCreatedDomainEvent(follower.UserId, follower.FollowerId));

            return follower;
        }
    }
}
