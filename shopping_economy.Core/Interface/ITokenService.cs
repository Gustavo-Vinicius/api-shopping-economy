using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopping_economy.Core.Entities;

namespace shopping_economy.Core.Interface
{
    public interface ITokenService
    {
        string GenerateAccessToken(string email);

        Employee ReadToken(string jwtToken);
    }
}