using Microsoft.EntityFrameworkCore;

namespace goodbyecouchpotato.Models;

public partial class GoodbyepotatoContext : DbContext
{
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			IConfiguration Config=new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json").Build();

			optionsBuilder.UseLazyLoadingProxies().UseSqlServer(Config.GetConnectionString("goodbyepotato"));
		}
	}
}

