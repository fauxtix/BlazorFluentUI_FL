using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Model
{
    public class UserModel : IUserModel
    {
        public UserModel(string IdUser, string UserName, string UserPassword)
        {
            Id = IdUser;
            Name = UserName;
            Password = UserPassword;
        }
        public UserModel() { }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
