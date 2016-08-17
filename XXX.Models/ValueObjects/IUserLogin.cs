namespace XXX.Models.ValueObjects
{
    public interface IUserLogin : IUserPassword
    {
        string Email { get; set; }
    }
}