using SignInTechnologys.Common.DbContexts;
using Microsoft.EntityFrameworkCore;
using SignInTechnologys.Interfaces;
using SignInTechnologys.Services;

namespace SignInTechnologys.Configuration.LayerConfiguration
{
	public static class DataAccessConfiguration
	{
		public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
		{
			string connectionString = configuration.GetConnectionString("DatabaseConnection");
			services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
			services.AddScoped<IAccountService, AccountService>();
		}
	}
}
