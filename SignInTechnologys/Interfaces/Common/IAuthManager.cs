using SignInTechnologys.Entities;

namespace SignInTechnologys.Interfaces.Common
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
    }
}
