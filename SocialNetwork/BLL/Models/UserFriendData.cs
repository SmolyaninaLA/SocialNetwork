using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.BLL.Models
{
    public class UserFriendData
    {
        public int Id { get; }
        public int User_id { get; set; }
        public int Friend_id { get; set; }
        public string Email { get; set; }

        
    }
}
