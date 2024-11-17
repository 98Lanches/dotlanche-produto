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
    public CategoriaEnum CategoriaId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
}
