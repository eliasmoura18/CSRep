using Domain.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities
{
    [Table("trade")]
    public class TradeEntity : BaseEntity
    {
        [Column("valor")]
        public double Valor { get; set; }

        [Column("clientsector")]
        public string ClientSector { get; set; }
    }
}
