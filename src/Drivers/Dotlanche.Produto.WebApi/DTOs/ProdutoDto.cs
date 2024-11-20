using System.ComponentModel.DataAnnotations;

namespace Dotlanche.Produto.WebApi.DTOs;

public class ProdutoDto
{
    public enum CategoriaEnum
    {
        Lanche = 1,
        Acompanhamento = 2,
        Bebida = 3,
        Sobremesa = 4,
    }
    [Required]
    public string Name { get; set; }
    [Required]
    [EnumDataType(typeof(CategoriaEnum), ErrorMessage = "The CategoriaId field must be a valid enum value.")]
    public CategoriaEnum CategoriaId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be greater than 0.")]
    public decimal Price { get; set; }
}
