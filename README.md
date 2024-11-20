# 🍔 Dotlanches Produto

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=98Lanches_dotlanche-produto&metric=coverage)](https://sonarcloud.io/summary/new_code?id=98Lanches_dotlanche-produto)

Microsserviço de produtos Dotlanches. Responsável pelo gerenciamento de produtos disponíveis para montagem dos combos de pedidos.

# Funcionalidades
- Registro de produto com suas informações de nome, descrição, preço e categoria.
- Edição de produtos já cadastrados pelos acessos gerenciais.
- Deleção de produtos pelos acessos gerenciais.
- Busca de produto por ID.
- Busca de lista de produtos pelos IDs.
- Busca de produtos por categorias.

# Stack
- .NET 8.0
- EntityFramework
- Postgresql
- NUnit
- Moq
- Reqnroll
- Docker
- Docker Compose
- Kubernetes
- GitHub Actions

# Arquitetura do Sistema
O serviço foi construído utilizando arquitetura hexagonal para organização interna. O banco de dados selecionado foi o Postgresql pela proximidade do time com esta ferramenta.

# Como executar o projeto

## Pré-requisitos
- Docker

1. Na raiz do projeto, execute o comando
```
docker-compose up
```
2. Acesse o navegador o endereço http://localhost:8080/swagger/index.html

# Testes
Tanto os testes de unidade quanto os testes de BDD encontram-se no diretório `test`.

Para executar os testes da aplicação, basta rodar o comando abaixo na raiz do projeto:
```
dotnet test
```
