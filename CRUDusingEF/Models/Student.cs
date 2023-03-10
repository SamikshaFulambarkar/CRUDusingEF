using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUDusingEF.Models
{
    [Table("tblStudent")]
    public class Student
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Course { get; set; }
    }
}
