Funcionalidade: Recuperar Produto existente

Cenário: Recuperar um produto existente
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria | idCategoria |
		| a0a518e4-f51c-4ca6-94a7-f343c1a1b338 | Lanche A | Um lanche para testar | 14,99     | Lanche    | 1           |
        | 0dabcc03-e5a0-407b-a876-d65b6c05c23c | Bebida A | Outra bebida de teste | 19,99     | Bebida    | 2           |
		Quando for consultado o produto com id a0a518e4-f51c-4ca6-94a7-f343c1a1b338
		Então deve retornar o produto Lanche A

Cenário: Recuperar um produto inexistente
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria | idCategoria |
		| a0a518e4-f51c-4ca6-94a7-f343c1a1b339 | Lanche B | Um lance pra testares | 16,99     | Lanche    | 1           |
        | 0dabcc03-e5a0-407b-a876-d65b6c05c23d | Bebida B | Outra bebid de testes | 18,99     | Bebida    | 2           |
		Quando for consultado o produto com id a0a518e4-f51c-4ca6-94a7-aaaaaaaaaaaa
		Então deve retornar status não encontrado

Cenário: Recuperar um produto existente pelo nome
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria | idCategoria |
		| 90a518e4-f51c-4ca6-94a7-f343c1a1b338 | Lanche C | Um lanche para testar | 17,99     | Lanche    | 1           |
        | 9dabcc03-e5a0-407b-a876-d65b6c05c23c | Bebida C | Outra bebida de teste | 12,99     | Bebida    | 2           |
		Quando for consultado o produto com nome Lanche C
		Então deve retornar o produto Lanche C

Cenário: Recuperar produtos em lista de pedido
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria | idCategoria |
		| b0a518e4-f51c-4ca6-94a7-f343c1a1b339 | Lanche D | Um lanche para testar | 16,99     | Lanche    | 1           |
        | 1dabcc03-e5a0-407b-a876-d65b6c05c23d | Bebida D | Bebida de teste       |  8,99     | Bebida    | 2           |
		Quando for consultado a lista de produtos com ids b0a518e4-f51c-4ca6-94a7-f343c1a1b339,1dabcc03-e5a0-407b-a876-d65b6c05c23d
		Então deve retornar os produtos Lanche D e Bebida D
