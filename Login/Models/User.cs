using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public enum Gender
    {
        男,
        女
    }
    public class User
    {
        [Key]
        public Guid UsersId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }

        public UserSession UserSession { get; set; }
    }

    public class UserSession
    {
        public int UserSessionId { get; set; }
        public string Value { get; set; }
    }
}
