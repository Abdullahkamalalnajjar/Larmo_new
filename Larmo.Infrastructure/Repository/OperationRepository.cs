using Larmo.Core.Repository;
using Larmo.Domain.Domain;
using Larmo.Infrastructure.Context;
using Larmo.Shared.Persistence;

namespace Larmo.Infrastructure.Repository;

public class OperationRepository(ApplicationContext context)
    : Repository<Operation>(context), IOperationRepository;