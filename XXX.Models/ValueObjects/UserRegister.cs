using System.ComponentModel.DataAnnotations.Schema;
using XXX.Models.Entities;

namespace XXX.Models.ValueObjects
{
    [NotMapped]
    public class UserRegister : User
    {
        public string Token { get; set; }
        public string Uuid { get; set; }
    }
}