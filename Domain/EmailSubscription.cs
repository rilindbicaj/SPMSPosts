using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string EmailAddress { get; set; }
        public bool Subscribed { get; set; }
    }
}