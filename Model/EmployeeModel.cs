using System.ComponentModel.DataAnnotations;

namespace APIAssignment1.Model
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string Emp_Name { get; set; } = string.Empty;
        public string Emp_Gender { get; set; } = string.Empty;
        
        public decimal Emp_Salary { get; set; }
        public string Emp_Mobile { get; set; } = string.Empty;
    }
}
