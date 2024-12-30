using System.ComponentModel.DataAnnotations;

namespace ConnectMySql.Model.DTO
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "Customer Name is Missing")]
        public string FullName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

    }
}
