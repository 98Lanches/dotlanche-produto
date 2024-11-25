Funcionalidade: Cadastrar novo Produto

Cenário: Cadastro de um novo produto
		Dado um produto com nome de "Lanche A" e com preço de 10,0 e com categoria 1 e com descrição "Um Lanche Para Testar"
		Quando a solicitação de cadastro de produto for enviada
		Então deve retornar o id do produto
