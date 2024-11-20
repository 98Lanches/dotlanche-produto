using Dotlanche.Produto.WebApi.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Dotlanche.Produto.Tests.WebApi.DTOs
{
    [TestFixture]
    public class ProdutoDtoTests
    {
        private ProdutoDto _validProdutoDto;

        [SetUp]
        public void Setup()
        {
            _validProdutoDto = new ProdutoDto
            {
                Name = "Produto A",
                CategoriaId = ProdutoDto.CategoriaEnum.Lanche,
                Description = "Descrição do Produto A",
                Price = 10.99m
            };
        }

        private List<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [Test]
        public void ProdutoDto_WithValidData_ShouldPassValidation()
        {
            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.IsEmpty(results);
        }

        [Test]
        public void ProdutoDto_WithoutName_ShouldFailValidation()
        {
            // Arrange
            _validProdutoDto.Name = null;

            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Name field is required.", results[0].ErrorMessage);
        }

        [Test]
        public void ProdutoDto_WithoutCategoriaId_ShouldFailValidation()
        {
            // Arrange
            _validProdutoDto.CategoriaId = 0;

            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.AreEqual(1, results.Count);
            System.Diagnostics.Debug.WriteLine(results[0].ErrorMessage);
            Assert.AreEqual("The CategoriaId field must be a valid enum value.", results[0].ErrorMessage);
        }

        [Test]
        public void ProdutoDto_WithoutDescription_ShouldFailValidation()
        {
            // Arrange
            _validProdutoDto.Description = null;

            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Description field is required.", results[0].ErrorMessage);
        }

        [Test]
        public void ProdutoDto_WithInvalidPrice_ShouldFailValidation()
        {
            // Arrange
            _validProdutoDto.Price = 0;

            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Price field must be greater than 0.", results[0].ErrorMessage);
        }

        [Test]
        public void ProdutoDto_WithEmptyName_ShouldFailValidation()
        {
            // Arrange
            _validProdutoDto.Name = string.Empty;

            // Act
            var results = ValidateModel(_validProdutoDto);

            // Assert
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("The Name field is required.", results[0].ErrorMessage);
        }
    }
}
