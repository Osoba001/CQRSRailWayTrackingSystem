namespace RailWayAppLibrary.Utility
{
    public interface IAuthenticationManager
    {
        string Authenticate(string name, string email, string role);
    }
}