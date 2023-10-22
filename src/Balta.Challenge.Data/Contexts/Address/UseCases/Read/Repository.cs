using Balta.Challenge.Core.Contexts.Address.Entities;
using Balta.Challenge.Core.Contexts.Address.UseCases.Read.Contracts;
using Balta.Challenge.Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Balta.Challenge.Data.Contexts.Address.UseCases.Read
{
    public class Repository : IRepository
    {
        private readonly ApiDbContext _context;

        public Repository(ApiDbContext context)
        {
            _context = context;
        }

        public Task<List<Locale>> GetListByExpressionAndFilter(string expression, FilterEnum filter, CancellationToken cancellationToken)
        {
            expression = expression.ToLower();

            IQueryable<Locale> query = _context
                .Locales
                .AsNoTracking()
                .Include(x => x.IBGECode)
                .Include(x => x.State);

            if (filter == FilterEnum.City)
            {
                query = query.Where(x => x.City.ToLower().Contains(expression));
            }

            if (filter == FilterEnum.State)
            {
                query = query.Where(x => x.State.Value.ToLower().Contains(expression));
            }

            if (filter == FilterEnum.IBGECode)
            {
                query = query.Where(x => x.IBGECode.Value.ToString().Contains(expression));
            }

            return query.ToListAsync();
        }
    }
}
