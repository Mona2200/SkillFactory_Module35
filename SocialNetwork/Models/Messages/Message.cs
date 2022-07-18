using SocialNetwork.Models.Users;

namespace SocialNetwork.Models.Messages
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }

        public User Sender { get; set; }

        public User Recipient { get; set; }
    }
}
