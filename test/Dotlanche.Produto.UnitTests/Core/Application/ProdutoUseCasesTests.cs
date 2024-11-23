using Dotlanche.Produto.Application.Ports;
using DotLanche.Produto.Domain.Entities;
using DotLanches.Application.Services;
using Moq;

namespace Dotlanche.Produto.Tests.Application.Services
{
    [TestFixture]
    public class ProdutoUseCasesTests
    {
        private Mock<IProdutoRepository> _repositoryMock;
        private ProdutoUseCases _produtoUseCases;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IProdutoRepository>();
            _produtoUseCases = new ProdutoUseCases(_repositoryMock.Object);
        }

        [Test]
        public async Task Add_ShouldCallRepositoryAdd_AndReturnResult()
        {
            // Arrange
            var produto = new RegistroProduto(Guid.NewGuid(), "Produto A", "Descrição", 50m, new Categoria { Id = 1, Name = "Lanches" });
            _repositoryMock.Setup(repo => repo.Add(produto)).ReturnsAsync(produto);

            // Act
            var result = await _produtoUseCases.Add(produto);

            // Assert
            _repositoryMock.Verify(repo => repo.Add(produto), Times.Once);
            Assert.AreEqual(produto, result);
        }

        [Test]
        public async Task Edit_ShouldCallRepositoryEdit_AndReturnResult()
        {
            // Arrange
            var produto = new RegistroProduto(Guid.NewGuid(), "Produto B", "Descrição atualizada", 60m, new Categoria { Id = 2, Name = "Bebidas" });
            _repositoryMock.Setup(repo => repo.Edit(produto)).ReturnsAsync(produto);

            // Act
            var result = await _produtoUseCases.Edit(produto);

            // Assert
            _repositoryMock.Verify(repo => repo.Edit(produto), Times.Once);
            Assert.AreEqual(produto, result);
        }

        [Test]
        public async Task Delete_ShouldCallRepositoryDelete_AndReturnResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var produto = new RegistroProduto(id, "Produto C", "Descrição", 30m, new Categoria { Id = 3, Name = "Doces" });
            _repositoryMock.Setup(repo => repo.Delete(id)).ReturnsAsync(produto);

            // Act
            var result = await _produtoUseCases.Delete(id);

            // Assert
            _repositoryMock.Verify(repo => repo.Delete(id), Times.Once);
            Assert.AreEqual(produto, result);
        }

        [Test]
        public async Task GetByCategoria_ShouldCallRepositoryGetByCategoria_AndReturnResult()
        {
            // Arrange
            var idCategoria = 1;
            var produtos = new List<RegistroProduto>
            {
                new RegistroProduto(Guid.NewGuid(), "Produto A", "Descrição", 50m, new Categoria { Id = 1, Name = "Lanches" })
            };
            _repositoryMock.Setup(repo => repo.GetByCategoria(idCategoria)).ReturnsAsync(produtos);

            // Act
            var result = await _produtoUseCases.GetByCategoria(idCategoria);

            // Assert
            _repositoryMock.Verify(repo => repo.GetByCategoria(idCategoria), Times.Once);
            Assert.AreEqual(produtos, result);
        }

        [Test]
        public async Task GetOrderProducts_ShouldCallRepositoryGetByIdList_AndReturnResult()
        {
            // Arrange
            var ids = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };
            var produtos = new List<RegistroProduto>
            {
                new RegistroProduto(ids[0], "Produto D", "Descrição", 70m, new Categoria { Id = 4, Name = "Snacks" }),
                new RegistroProduto(ids[1], "Produto E", "Descrição", 80m, new Categoria { Id = 4, Name = "Snacks" })
            };
            _repositoryMock.Setup(repo => repo.GetByIdList(ids)).ReturnsAsync(produtos);

            // Act
            var result = await _produtoUseCases.GetOrderProducts(ids);

            // Assert
            _repositoryMock.Verify(repo => repo.GetByIdList(ids), Times.Once);
            Assert.AreEqual(produtos, result);
        }

        [Test]
        public async Task GetById_ShouldCallRepositoryGetById_AndReturnResult()
        {
            // Arrange
            var id = Guid.NewGuid();
            var produto = new RegistroProduto(id, "Produto F", "Descrição", 90m, new Categoria { Id = 5, Name = "Congelados" });
            _repositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync(produto);

            // Act
            var result = await _produtoUseCases.GetById(id);

            // Assert
            _repositoryMock.Verify(repo => repo.GetById(id), Times.Once);
            Assert.AreEqual(produto, result);
        }

        [Test]
        public async Task GetByName_ShouldCallRepositoryGetByName_AndReturnResult()
        {
            // Arrange
            var name = "Produto G";
            var produto = new RegistroProduto(Guid.NewGuid(), name, "Descrição", 100m, new Categoria { Id = 6, Name = "Bebidas" });
            _repositoryMock.Setup(repo => repo.GetByName(name)).ReturnsAsync(produto);

            // Act
            var result = await _produtoUseCases.GetByName(name);

            // Assert
            _repositoryMock.Verify(repo => repo.GetByName(name), Times.Once);
            Assert.AreEqual(produto, result);
        }
    }
}
