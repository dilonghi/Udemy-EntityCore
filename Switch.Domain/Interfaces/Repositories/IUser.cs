using System.Collections.Generic;
using System.Security.Claims;

namespace Switch.Domain.Interfaces.Repositories
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
