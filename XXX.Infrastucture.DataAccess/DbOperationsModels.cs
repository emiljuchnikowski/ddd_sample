using System;

namespace XXX.Infrastructure.DataAccess
{
    public class RegisterUserModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Uuid { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }

    public class UpdateUserPasswordModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid ChangePasswordToken { get; set; }
    }
}