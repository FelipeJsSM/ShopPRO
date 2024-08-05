using ShopPRO.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopPRO.Modules.Domain.Entities
{
    [Table("Scores", Schema = "Stats")]
    public class Scores : BaseEntity<string>
    {
        [Key]
        [Column("studentid")]
        public override string Id { get; set ; }
        public string testid { get; set; }
        public byte score { get; set; }
    }
}
