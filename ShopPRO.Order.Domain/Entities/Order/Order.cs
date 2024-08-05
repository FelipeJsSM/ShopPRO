using ShopPRO.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPRO.Modules.Domain.Entities.Order
{
    public class Order : BaseEntity<int>
    {
        [Column("orderid")]
        public override int Id { get; set; }
    }
}
