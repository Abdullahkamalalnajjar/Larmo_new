using Microsoft.EntityFrameworkCore;

namespace Larmo.Shared.Persistence;

public abstract class BaseContext(DbContextOptions options) : DbContext(options);