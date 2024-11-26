Funcionalidade: Editar Produto existente

Cenário: Editar um produto existente
		Dado produtos cadastrado:
		| Id                                   | Name        | Description  | Price     | Categoria    | idCategoria |
		| 50b518e4-f51c-4ca6-94a7-f343c1a1b338 | Sobremesa A | Torta mocada | 11,99     | Sobremesa    | 4           |
		Quando for solicitado editar produto com id 50b518e4-f51c-4ca6-94a7-f343c1a1b338 e valores Nome Sobremesa A e Description Torta mocada e Price 20,00 e idCategoria 4
		Então retornar o produto Sobremesa A