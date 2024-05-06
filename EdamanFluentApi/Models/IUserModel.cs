using System;
using System.Collections.Generic;
using System.Text;

namespace EdamanFluentApi.Model
{
    interface IUserModel
    {
        string Id { get; set; }
        string Name { get; set; }
        string Password { get; set; }
    }
}
