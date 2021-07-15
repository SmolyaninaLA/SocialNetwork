using SocialNetwork.BLL;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.BLL.Models;
using SocialNetwork.PLL.Helpers;
using SocialNetwork.BLL.Exceptions;

namespace SocialNetwork.PLL.Views
{
    public class UserAddFriend
    {
        UserFriendService userFriendService;

        public UserAddFriend(UserFriendService UserFriendService)
        {
            this.userFriendService = UserFriendService;
                       
        }

        public void Show(User user)
        {
            var userFriendData = new UserFriendData();

            Console.Write("Введите почтовый адрес друга: ");
            
            userFriendData.Email = Console.ReadLine();

            userFriendData.User_id = user.Id;

            try
            {
                this.userFriendService.AddFriend(userFriendData);
                SuccessMessage.Show("Добавление друга прошло успешно.");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение eMail.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (Exception)
            {
                AlertMessage.Show("произошла ошибка добавления  друга.");
            }
        }
    }
}
