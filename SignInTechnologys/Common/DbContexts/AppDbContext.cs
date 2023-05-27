using Microsoft.EntityFrameworkCore;
using SignInTechnologys.Entities;

namespace SignInTechnologys.Common.DbContexts;
public class AppDbContext : DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> options)
		: base(options)
	{

	}

	public virtual DbSet<User> Users { get; set; } = default!;
}
