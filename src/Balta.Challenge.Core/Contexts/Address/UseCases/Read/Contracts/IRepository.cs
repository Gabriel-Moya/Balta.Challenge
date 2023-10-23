
using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Enums;

namespace Balta.Challenge.Core.Contexts.Address.UseCases.Read.Contracts;
public interface IRepository
{
    Task<List<Locale>> GetListByExpressionAndFilter(string expression, FilterEnum filter, CancellationToken cancellationToken);
}
