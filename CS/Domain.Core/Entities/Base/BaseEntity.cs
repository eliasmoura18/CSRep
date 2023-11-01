using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Core.Entities.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("datainsercao")]
        public DateTime DataInsercao { get; set; }
        [Column("dataalteracao")]
        public DateTime DataAlteracao { get; set; }
        [Column("dataexclusao")]
        public DateTime DataExclusao { get; set; }
    }
}
