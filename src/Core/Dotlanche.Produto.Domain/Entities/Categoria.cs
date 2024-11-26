#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

using System.ComponentModel.DataAnnotations;

namespace DotLanche.Produto.Domain.Entities;

public class Categoria
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}