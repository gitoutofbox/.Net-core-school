using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace MySchool.Models
{
    public class StudentMaster
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }

        //public ICollection<StudentDetails> StudentDetails { get; } = new List<StudentDetails>();

        public StudentDetails? Student_details { get; set; } // Reference navigation to dependent
    }
}
