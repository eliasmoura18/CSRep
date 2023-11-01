using Domain.Core.Entities;
using Domain.Core.Interface;
using Infraestructure.Context;
using Infraestructure.Repositories.Base;

namespace Infraestructure.Repositories
{
    public class TradeRepository : BaseRepository<TradeEntity>, ITradeRepository
    {
        public TradeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
