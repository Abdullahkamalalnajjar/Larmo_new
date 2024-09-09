using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Larmo.Shared.Persistence;

namespace Larmo.Infrastructure.Context;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : BaseContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}