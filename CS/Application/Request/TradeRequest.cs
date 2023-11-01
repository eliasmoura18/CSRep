using Application.DTO;

namespace Application.Request
{
    public class TradeRequest : ITrade
    {
        public double value { get; set; }

        public string clientSector { get; set; }
    }
}
