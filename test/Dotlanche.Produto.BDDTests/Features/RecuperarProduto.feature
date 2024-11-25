Funcionalidade: Recuperar Produto existente

Cenário: Recuperar um produto existente
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria |
		| a0a518e4-f51c-4ca6-94a7-f343c1a1b338 | Lanche A | Um lanche para testar | 14,99     | Lanche    |
        | 0dabcc03-e5a0-407b-a876-d65b6c05c23c | Lanche B | Outro lanche de teste | 19,99     | Lanche    |
		Quando for consultado o produto com id a0a518e4-f51c-4ca6-94a7-f343c1a1b338
		Então deve retornar o produto

Cenário: Recuperar um produto inexistente
		Dado produtos cadastrado:
		| Id                                   | Name     | Description           | Price     | Categoria |
		| a0a518e4-f51c-4ca6-94a7-f343c1a1b339 | Lanche C | Um lance pra testares | 16,99     | Lanche    |
        | 0dabcc03-e5a0-407b-a876-d65b6c05c23d | Lanche D | Outro lance de testes | 18,99     | Lanche    |
		Quando for consultado o produto com id a0a518e4-f51c-4ca6-94a7-aaaaaaaaaaaa
		Então deve retornar status não encontrado
