using System.ComponentModel.DataAnnotations;

namespace API.DTOs;
public class ProductCreateDto
{
    [Required(ErrorMessage = "El nombre del producto es un campo requerido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del producto debe tener entre 3 y 100 caracteres.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El precio del producto es un campo requerido.")]
    [Range(1, 1000000, ErrorMessage = "El precio del producto debe estar entre 1 y 1000000.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La marca del producto es un campo requerido.")]
    [Range(1, int.MaxValue, ErrorMessage = "El ID de la marca del producto debe ser un número entero positivo.")]
    public int BrandId { get; set; }
}