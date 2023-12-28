using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Vezeeta.Infrastructure.Data;

public class VezeetaDbContextFactory : IDesignTimeDbContextFactory<VezeetaDbContext>
{
    private readonly IServiceProvider _serviceProvider;

    public VezeetaDbContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public VezeetaDbContextFactory() {}
    public VezeetaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<VezeetaDbContext>();
        var connectionString = "Server=.;Database=DatabaseVezeetaBackup;Trusted_Connection=True;TrustServerCertificate=True"; 
        optionsBuilder.UseSqlServer(connectionString);

        return new VezeetaDbContext(optionsBuilder.Options);
    }
}
