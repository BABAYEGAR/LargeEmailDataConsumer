using System.Collections.Generic;

namespace LargeDataEmailConsumer.Models.Entities
{
    public class UserEmail
    {
        public List<AppUser> AppUsers { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string MessageCategory { get; set; }
    }
}
