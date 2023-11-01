using Application.DTO;
using Application.Request;
using Azure.Core;
using Domain.Core.Entities;
using Domain.Core.Interface;

namespace Application.Business
{
    public class TradeBusiness
    {
        private readonly ITradeRepository tradeRepository;
        private readonly IUnitOfWork unitOfWork;

        public TradeBusiness(IUnitOfWork unitOfWork, ITradeRepository clienteRepository)
        {
            this.unitOfWork = unitOfWork;
            this.tradeRepository = clienteRepository;
        }

        public List<string> GetCategories(List<TradeRequest> trades)
        {
            try
            {
                var retorno = new List<string>();

                foreach (var trade in trades)
                {
                    retorno.Add(BusinessRules.TradeCategory.GetCategory(trade));
                }

                return retorno;
            }
            catch
            {
                return new List<string>() { "Something unexpected happened" };
            }
        }

        public string NovoTrade(List<TradeRequest> trades)
        {
            try
            {
                foreach (var trade in trades)
                {
                    var tEntity = new TradeEntity()
                    {
                        ClientSector = trade.clientSector,
                        Valor = trade.value,
                    };

                    tradeRepository.Create(tEntity);
                }

                unitOfWork.Commit();

                return "All trades were created successfully";
            }
            catch
            {
                return "Something unexpected happened";
            }
        }
    }
}
