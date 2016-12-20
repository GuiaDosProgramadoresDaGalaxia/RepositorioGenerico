# RepositorioGenerico

Implementação em camadas (modelo DDD) utilizando o repositorio pattern e o unity of work nativos do Entity Framework. Banco de dados = SqlServer.

#Instruções 

1 - Você precisará rodar o 'Update-Database' para criar o BD na sua maquina.

2 - A super entidade é a 'Biblioteca', todas as demais criadas devem conter a referencia para qual biblioteca está vinculada. Sendo assim, é
importante que a primeira entidade a ser criada seja a biblioteca matriz. (Não está no Seed).

Biblioteca novaBiblioteca = new Biblioteca() { Nome = "Matriz", Endereco = "Algum Endereco" };
repositorio.Criar(novaBiblioteca);
repositorio.Salvar();

3 - As querys em sua maioria tem 5 argumentos, seguindo a ordem: Filtro, Ordenacao, Skip, Take, Propriedades a serem incluidas.

a) Filtro = expressao lambda, como o nome já diz, esse argumento representa o 'Where' da query.

b) Ordenacao = expressao lambda, esse argumento representa o 'ordeby'.

c) Skip = int, para paginação.

d) Take = int, para paginação

e) Propriedades = params[] expressão lambda, esse argumento representa as prorpiedades de navegação que serão incluídas (Include())
no resultado da query. Essas propriedades precisam ser as últimas a serem referenciadas na chamada do metodo:

var biblioteca = repositorio.ObterPrimeiro<Biblioteca>(null, null, c => c.Autores, c => c.Secoes, c => c.Livros);


