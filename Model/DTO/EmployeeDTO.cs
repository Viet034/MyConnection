using System.ComponentModel.DataAnnotations;

namespace ConnectMySql.Model.DTO
{
    public class EmployeeDTO
    {
        [Required(ErrorMessage = "Employee Name is Missing")]
        public string EmployeeName { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public string Gender { get; set; }


    }
}
