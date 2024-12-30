using System.ComponentModel.DataAnnotations;

namespace ConnectMySql.Model.DTO;


public class ProductDTO
{
    [Required(ErrorMessage = "Product Name is Missing")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is Missing")]
    public decimal Price { get; set; }
}
