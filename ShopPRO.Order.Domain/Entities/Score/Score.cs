using ShopPRO.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPRO.Modules.Domain.Entities.Score
{
    public class Score : BaseEntity<string>
    {
        [Column("studentid")]
        public override string Id { get; set; }
    }
}
