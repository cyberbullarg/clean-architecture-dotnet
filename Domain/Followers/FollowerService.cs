using Domain.Users;
using SharedKernel;

namespace Domain.Followers
{
    public sealed class FollowerService
    {
        private readonly IFollowerRepository _followerRepository;

        public FollowerService(IFollowerRepository followerRepository)
        {
            _followerRepository = followerRepository;
        }

        public async Task<Result> StartFollowing(User user, User followed, DateTime date, CancellationToken cancellationToken)
        {
            // Validate user & followed
            if (user.Id == followed.Id)
            {
                return FollowerErrors.SameUser;
            }

            if (!followed.HasPublicProfile)
            {
                return FollowerErrors.NonPublicProfile;
            }

            // Check if not following
            if (await _followerRepository.IsAlreadyFollowingAsync(user.Id, followed.Id, cancellationToken))
            {
                return FollowerErrors.AlreadyFollowing;
            }

            // Create follower
            Follower follower = new(user.Id, followed.Id, date);

            _followerRepository.Insert(follower);

            // Send notification...

            return Result.Success();
        }
    }
}
