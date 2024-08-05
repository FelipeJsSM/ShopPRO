using ShopPRO.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopPRO.Modules.Domain.Entities
{
    [Table("Tests", Schema = "Stats")]
    public class Tests : BaseEntity<string>
    {
        [Key]
        [Column("testid")]
        public override string Id { get ; set ; }   
    }
}
