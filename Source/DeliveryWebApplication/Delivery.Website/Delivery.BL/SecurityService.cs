using Delivery.BL.Contracts;
using Delivery.Models;
using System;
using System.Collections.Generic;

namespace Delivery.BL
{
    public class SecurityService : ISecurityService
    {
        private IUserService _userService;
        private static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();

        public SecurityService(IUserService userService)
        {
            _userService = userService;
        }

        public bool IsSessionExists(string token)
        {
            return SessionStorage.ContainsKey(token);
        }

        public string CreateNewSession(int userId)
        {
            string token = GenerateToken();
            while (SessionStorage.ContainsKey(token))
            {
                token = GenerateToken();
            }
            SessionStorage.Add(token, userId);
            return token;
        }

        public void DeleteSession(string token)
        {
            SessionStorage.Remove(token);
        }

        public User GetUser(string token)
        {
            return IsSessionExists(token) ? _userService.GetById(SessionStorage[token]) : null;
        }

        private string GenerateToken()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Replace("=", "").Replace("+", "");
        }

    }
}
