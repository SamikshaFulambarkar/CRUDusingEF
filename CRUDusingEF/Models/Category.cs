using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusingEF.Models
{
    [Table("tblProduct")]
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
