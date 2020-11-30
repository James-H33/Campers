using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Campers.Models
{
    public class UserProfile
    {
        public int Id { get; set; } = 0;
        public string Username { get; set; } = "";

        public bool isLoggedIn()
        {
            return Id != 0 && !String.IsNullOrEmpty(Username);
        }
    }
}
