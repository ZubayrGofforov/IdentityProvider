using SignInTechnologys.Dtos.Accounts;

namespace SignInTechnologys.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto);

        public Task<string> LoginAsync(AccountLoginDto accountLoginDto);
    }
}
