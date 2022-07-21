using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork.Models.Users;
using SocialNetwork.Models.Friends;
using SocialNetwork.Models.Messages;

namespace SocialNetwork.Data.Repos
{
    public class FriendsRepository : Repository<Friend>
    {
        public FriendsRepository(ApplicationDbContext db)
      : base(db)
        {

        }


        public async Task AddFriend(User target, User Friend)
        {
            var friends = await Set.FirstOrDefaultAsync(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends == null)
            {
                var item = new Friend()
                {
                    UserId = target.Id,
                    User = target,
                    CurrentFriend = Friend,
                    CurrentFriendId = Friend.Id,
                };

                await Create(item);
            }
        }

        public async Task<List<User>> GetFriendsByUser(User target)
        {
            var friends = await Set.Include(x => x.CurrentFriend).Where(x => x.User.Id == target.Id).Select(x => x.CurrentFriend).ToListAsync();

            return friends;
        }


        public async Task DeleteFriend(User target, User Friend)
        {
            var friends = await Set.FirstOrDefaultAsync(x => x.UserId == target.Id && x.CurrentFriendId == Friend.Id);

            if (friends != null)
            {
                await Delete(friends);
            }
        }

    }
}
