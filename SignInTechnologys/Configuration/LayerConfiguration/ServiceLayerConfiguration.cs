using SignInTechnologys.Interfaces;
using SignInTechnologys.Interfaces.Common;
using SignInTechnologys.Services;
using SignInTechnologys.Services.Common;

namespace SignInTechnologys.Configuration.LayerConfiguration
{
	public static class ServiceLayerConfiguration
	{
		public static void AddService(this IServiceCollection services)
		{
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IFileService, FileService>();
			services.AddScoped<IAuthManager, AuthManager>();
        }
	}
}
