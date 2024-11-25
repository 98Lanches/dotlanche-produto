using DotLanche.Produto.Domain.Exceptions;

namespace DotLanche.Produto.Domain.Entities.Tests
{
    [TestFixture]
    public class RegistroProdutoTests
    {
        [Test]
        public void Constructor_WithValidGuid_ShouldSetId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var registro = new RegistroProduto(id);

            // Assert
            Assert.AreEqual(id, registro.Id);
        }

        [Test]
        public void Constructor_WithValidParameters_ShouldInitializeProperties()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Product A";
            var description = "Description for Product A";
            var price = 100.50m;
            var categoria = new Categoria(); // Mock or actual instance

            // Act
            var registro = new RegistroProduto(id, name, description, price, categoria);

            // Assert
            Assert.AreEqual(id, registro.Id);
            Assert.AreEqual(name, registro.Name);
            Assert.AreEqual(description, registro.Description);
            Assert.AreEqual(price, registro.Price);
            Assert.AreEqual(categoria, registro.Categoria);
        }

        [Test]
        public void Constructor_WithNullName_ShouldThrowDomainValidationException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var description = "Valid description";
            var price = 100.50m;
            var categoria = new Categoria();

            // Assert
            Assert.Throws<DomainValidationException>(() => new RegistroProduto(id, null, description, price, categoria));
        }

        [Test]
        public void Constructor_WithEmptyDescription_ShouldThrowDomainValidationException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Valid Name";
            var price = 100.50m;
            var categoria = new Categoria();

            // Assert
            Assert.Throws<DomainValidationException>(() => new RegistroProduto(id, name, string.Empty, price, categoria));
        }

        [Test]
        public void Constructor_WithZeroPrice_ShouldThrowDomainValidationException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Valid Name";
            var description = "Valid Description";
            var categoria = new Categoria();

            // Assert
            Assert.Throws<DomainValidationException>(() => new RegistroProduto(id, name, description, 0m, categoria));
        }

        [Test]
        public void Constructor_WithNullCategoria_ShouldThrowDomainValidationException()
        {
            // Arrange
            var id = Guid.NewGuid();
            var name = "Valid Name";
            var description = "Valid Description";
            var price = 100.50m;

            // Assert
            Assert.Throws<DomainValidationException>(() => new RegistroProduto(id, name, description, price, null));
        }
    }
}
