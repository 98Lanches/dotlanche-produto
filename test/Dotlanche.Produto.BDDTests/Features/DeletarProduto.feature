Funcionalidade: Deletar Produto existente

Cenário: Deletar um produto existente
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria | idCategoria |
		| c0a518e4-f51c-4ca6-94a7-f343c1a1b338 | Lanche A | Um lanche para testar | 14,99     | Lanche    | 1           |
		Quando solicitar que delete o produto com id c0a518e4-f51c-4ca6-94a7-f343c1a1b338
		Então deve apagar o registro
		E retornar o objeto apagado
