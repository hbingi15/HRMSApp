namespace HRMSApplication.Contracts
{
    public interface IAuthent
    {
        string GenerateToken(string username, string role);
    }
}
