using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class EmailSubscription
    {
        [Key]
        public Guid User { get; set; }
    }
}