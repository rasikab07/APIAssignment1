using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIAssignment1.EFCore
{
    [Table("employee")]
    public class Employee
    {
        [Key,Required]
        public int id { get; set; }
        public string Emp_Name { get; set; } = string.Empty;
        public string Emp_Gender { get; set; } = string.Empty;
        public decimal Emp_Salary { get; set; }
        public string Emp_Mobile { get; set; } = string.Empty;
    }
}
