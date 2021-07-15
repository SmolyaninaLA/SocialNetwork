using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.BLL.Models;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.DAL.Entities;

namespace SocialNetwork.BLL.Services
{
    public class UserFriendService
    {
        FriendRepository friendRepository;
        UserRepository userRepository;

        public UserFriendService ()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        public void AddFriend(UserFriendData userFriendData)
        {
            if (String.IsNullOrEmpty(userFriendData.Email))
                throw new ArgumentNullException();
            
            if (!new EmailAddressAttribute().IsValid(userFriendData.Email))
                throw new ArgumentNullException();

            var findUserEntity = this.userRepository.FindByEmail(userFriendData.Email);
            if (findUserEntity is null) throw new UserNotFoundException();


            var friendEntity = new FriendEntity()
            {
                user_id = userFriendData.User_id,
                friend_id = findUserEntity.id
                
            };

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();

        }

    }
}
