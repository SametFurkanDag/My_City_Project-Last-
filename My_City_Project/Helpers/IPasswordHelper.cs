namespace My_City_Project.Helpers
{
    public interface IPasswordHelper
    {
        string HashPassword(string password);
        bool VerifyPassword(string passwordHash, string password);
    }
}
