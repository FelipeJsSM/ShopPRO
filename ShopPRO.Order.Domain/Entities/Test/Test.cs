using ShopPRO.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPRO.Modules.Domain.Entities.Test
{
    public class Test : BaseEntity<string>
    {
        [Column("testid")]
        public override string Id { get; set; }
    }
}
