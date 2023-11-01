using Application.Business;
using Application.DTO;
using Application.Request;
using Domain.Core.Entities;
using Domain.Core.Interface;
using Infraestructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ITradeRepository tradeRepository;
        private readonly IUnitOfWork unitOfWork;

        public TradeController(ITradeRepository tradeRepository, IUnitOfWork unitOfWork)
        {
            this.tradeRepository = tradeRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<TradeEntity>>> BuscarTrades()
        {
            try
            {
                List<TradeEntity> trades = tradeRepository.GetAll();
                return Ok(trades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TradeEntity>> BuscarPorId(int id)
        {
            try
            {
                TradeEntity trades = tradeRepository.Get(id);
                return Ok(trades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> NewTrade([FromBody] List<TradeRequest> trade)
        {
            try
            {
                TradeBusiness tradeBusiness = new TradeBusiness(unitOfWork, tradeRepository);
                string retorno = tradeBusiness.NovoTrade(trade);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("Categories")]
        [HttpPost]
        public async Task<ActionResult<List<string>>> TradeCategories([FromBody] List<TradeRequest> trade)
        {
            try
            {
                TradeBusiness tradeBusiness = new TradeBusiness(unitOfWork, tradeRepository);
                tradeBusiness.NovoTrade(trade);
                List<string> retorno = tradeBusiness.GetCategories(trade);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
