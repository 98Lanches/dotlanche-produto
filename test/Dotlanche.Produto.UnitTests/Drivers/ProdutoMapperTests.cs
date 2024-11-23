using Dotlanche.Produto.WebApi.DTOs;
using Dotlanche.Produto.WebApi.Mappers;

namespace Dotlanche.Produto.Tests.Mappers
{
    [TestFixture]
    public class ProdutoMapperTests
    {
        [Test]
        public void ToDomainModel_WithValidDto_ReturnsExpectedDomainModel()
        {
            // Arrange
            var id = Guid.NewGuid();
            var produtoDto = new ProdutoDto
            {
                Name = "Lanche A",
                Description = "Descrição do Lanche A",
                Price = 9.99m,
                CategoriaId = ProdutoDto.CategoriaEnum.Lanche
            };

            // Act
            var result = produtoDto.ToDomainModel(id);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(id, result.Id);
            Assert.AreEqual(produtoDto.Name, result.Name);
            Assert.AreEqual(produtoDto.Description, result.Description);
            Assert.AreEqual(produtoDto.Price, result.Price);
            Assert.NotNull(result.Categoria);
            Assert.AreEqual((int)produtoDto.CategoriaId, result.Categoria.Id);
        }

        [Test]
        public void ToDomainModel_WithNullDto_ThrowsArgumentNullException()
        {
            // Arrange
            ProdutoDto? produtoDto = null;
            var id = Guid.NewGuid();

            // Assert
            Assert.Throws<ArgumentNullException>(() => produtoDto!.ToDomainModel(id));
        }

        [Test]
        public void ToDomainModel_WithEmptyGuid_SuccessfullyMaps()
        {
            // Arrange
            var produtoDto = new ProdutoDto
            {
                Name = "Lanche B",
                Description = "Descrição do Lanche B",
                Price = 19.99m,
                CategoriaId = ProdutoDto.CategoriaEnum.Bebida
            };

            var emptyGuid = Guid.Empty;

            // Act
            var result = produtoDto.ToDomainModel(emptyGuid);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(emptyGuid, result.Id);
            Assert.AreEqual(produtoDto.Name, result.Name);
            Assert.AreEqual(produtoDto.Description, result.Description);
            Assert.AreEqual(produtoDto.Price, result.Price);
            Assert.NotNull(result.Categoria);
            Assert.AreEqual((int)produtoDto.CategoriaId, result.Categoria.Id);
        }
    }
}
