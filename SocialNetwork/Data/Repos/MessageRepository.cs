using SocialNetwork.Models.Messages;

namespace SocialNetwork.Data.Repos
{
    public class MessageRepository : Repository<Message>
    {
        public MessageRepository(ApplicationDbContext db)
        : base(db)
        {

        }
    }
}
