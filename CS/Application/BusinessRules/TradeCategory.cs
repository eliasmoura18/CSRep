using Application.DTO;

namespace Application.BusinessRules
{
    public class TradeCategory
    {
        public static string GetCategory(ITrade trade)
        {
            if (trade.value < 1000000)
                return "LOWRISK";

            if (trade.clientSector.ToUpper() == "PUBLIC")
                return "MEDIUMRISK";

            if (trade.clientSector.ToUpper() == "PRIVATE")
                return "HIGHRISK";

            return "Sector Not Found";
        }
    }
}
