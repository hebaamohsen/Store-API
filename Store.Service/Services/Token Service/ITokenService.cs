using Store.Data.Entities.IdentityEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Services.Token_Service
{
    public interface ITokenService
    {
        string GenerateToken(AppUser appUser);
    }
}
