using Microsoft.EntityFrameworkCore;
using SignInTechnologys.Common.DbContexts;
using SignInTechnologys.Common.Exceptions;
using SignInTechnologys.Common.Security;
using SignInTechnologys.Dtos.Accounts;
using SignInTechnologys.Interfaces;
using SignInTechnologys.Interfaces.Common;
using SignInTechnologys.Entities;

namespace SignInTechnologys.Services
{
    public class AccountService : IAccountService
    {
        private readonly AppDbContext _repository;
        private readonly IFileService _fileService;
        private readonly IAuthManager _authManager;

        public AccountService(AppDbContext appDbContext, IFileService fileService, IAuthManager authManager)
        {
            this._repository = appDbContext;
            this._fileService = fileService;
            this._authManager = authManager;
        }

        public async Task<string> LoginAsync(AccountLoginDto accountLoginDto)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountLoginDto.Email);
            if (user == null) throw new ModelErrorException(nameof(accountLoginDto.Email), "Not found user");

            var hasherResult = PasswordHasher.Verify(accountLoginDto.Password, user.Salt, user.PasswordHash);
            if (hasherResult)
            {
                string token = _authManager.GenerateToken(user);
                return token;
            }
            else throw new ModelErrorException(nameof(accountLoginDto.Password), "Password is wrong!");
        }

        public async Task<bool> RegisterAsync(AccountRegisterDto accountRegisterDto)
        {
            var email = await _repository.Users.FirstOrDefaultAsync(x => x.Email == accountRegisterDto.Email);
            if (email is not null) throw new ModelErrorException(nameof(accountRegisterDto.Email), "Email is already exist");

            var phoneNumber = await _repository.Users.FirstOrDefaultAsync(x => x.PhoneNumber == accountRegisterDto.PhoneNumber);
            if (phoneNumber is not null) throw new ModelErrorException(nameof(accountRegisterDto.PhoneNumber), "Phone Number is already exist");

            var hasherResult = PasswordHasher.Hash(accountRegisterDto.Password);
            var user = (User)accountRegisterDto;
            user.PasswordHash = hasherResult.Hash;
            user.Salt = hasherResult.Salt;

            if (accountRegisterDto.Image is not null)
                user.ImagePath = await _fileService.SaveImageAsync(accountRegisterDto.Image);
            
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            _repository.Users.Add(user);
            var dbResult = await _repository.SaveChangesAsync();
            return dbResult > 0;
        }
    }
}
