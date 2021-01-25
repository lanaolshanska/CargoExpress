using Delivery.Models;

namespace Delivery.BL.Contracts
{
    public interface ISecurityService
    {
        bool IsSessionExists(string token);
        string CreateNewSession(int userId);
        void DeleteSession(string token);
        User GetUser(string token);
    }
}
