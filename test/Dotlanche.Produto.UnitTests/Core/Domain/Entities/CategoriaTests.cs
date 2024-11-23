namespace DotLanche.Produto.Domain.Entities.Tests
{
    [TestFixture]
    public class CategoriaTests
    {
        [Test]
        public void Categoria_ShouldInitializeWithDefaultValues()
        {
            // Act
            var categoria = new Categoria();

            // Assert
            Assert.AreEqual(0, categoria.Id);
            Assert.IsNull(categoria.Name);
        }

        [Test]
        public void Categoria_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var name = "Lanches";

            // Act
            var categoria = new Categoria
            {
                Id = id,
                Name = name
            };

            // Assert
            Assert.AreEqual(id, categoria.Id);
            Assert.AreEqual(name, categoria.Name);
        }

        [Test]
        public void Categoria_Name_ShouldAllowEmptyString()
        {
            // Act
            var categoria = new Categoria { Name = string.Empty };

            // Assert
            Assert.AreEqual(string.Empty, categoria.Name);
        }

        [Test]
        public void Categoria_Name_ShouldAllowNull()
        {
            // Act
            var categoria = new Categoria { Name = null };

            // Assert
            Assert.IsNull(categoria.Name);
        }
    }
}
