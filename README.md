# Sistema de Estoque API — Catálogo de Livros e Autores

API REST em **C# / ASP.NET Core Web API** para gerenciamento de um catálogo de livros e autores, com persistência em **SQL Server** via **Entity Framework Core**.

> Observação: o nome do repositório é "SistemaEstoqueAPI", mas o domínio implementado é um catálogo de Livros/Autores (poderia representar, por exemplo, o estoque de uma livraria).

## Tecnologias

- C# / .NET 10
- ASP.NET Core Web API
- Entity Framework Core (Code First + Migrations)
- SQL Server

## Arquitetura

O projeto segue uma separação em camadas:

- **Controllers** — expõem os endpoints REST (`AutorController`, `LivroController`)
- **Services** — contêm a lógica de negócio, implementadas via interfaces (`IAutorService`, `ILivroInterface`) e injetadas por Dependency Injection
- **DTOs** — objetos de entrada específicos para criação e edição (`AutorCriacaoDto`, `AutoredicaoDto`, `LivroCriacaoDto`, `LivroEdicaoDto`), evitando expor os models diretamente na API
- **Models** — entidades do banco (`AutorModel`, `LivrosModel`), com relacionamento 1:N entre Autor e Livros
- **ResponseModel<T>** — envelope padrão de resposta, com `Mensagem`, `Status` e `Dados`, usado em todos os endpoints para manter um formato de retorno consistente

## Funcionalidades

**Autores**
- Listar todos os autores
- Buscar autor por ID
- Buscar autor pelo ID de um livro
- Criar, editar e excluir autor

**Livros**
- Listar todos os livros
- Buscar livro por ID
- Buscar livros pelo ID do autor
- Criar, editar e excluir livro

## Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| GET    | /api/Autor/ListarAutores | Lista todos os autores |
| GET    | /api/Autor/BuscarAutorPorId/{idAutor} | Busca autor por ID |
| GET    | /api/Autor/BuscarAutorPorIdLivro/{idlivro} | Busca autor a partir do ID de um livro |
| POST   | /api/Autor/CriarAutor | Cria um novo autor |
| PUT    | /api/Autor/EditarAutor | Edita um autor existente |
| DELETE | /api/Autor/ExcluirAutor | Remove um autor |
| GET    | /api/Livro/ListarLivros | Lista todos os livros |
| GET    | /api/Livro/BuscarLivroPorId/{idLivro} | Busca livro por ID |
| GET    | /api/Livro/BuscarLivroPorIdAutor/{idAutor} | Lista livros de um autor |
| POST   | /api/Livro/CriarLivro | Cria um novo livro |
| PUT    | /api/Livro/EditarLivro | Edita um livro existente |
| DELETE | /api/Livro/ExcluirLivro | Remove um livro |

## Como executar

```bash
git clone https://github.com/Nikerson95/SistemaEstoqueAPI.git
cd SistemaEstoqueAPI/WebApplication1
```

Configure a connection string do SQL Server em `appsettings.json` (chave `DefaultConnection`), depois:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Como o projeto usa `AddOpenApi()`, a documentação da API fica disponível em `/openapi/v1.json` durante o ambiente de desenvolvimento.

## O que aprendi com esse projeto

- Separação em camadas (Controller → Service → DbContext) usando injeção de dependência nativa do ASP.NET Core.
- Uso de DTOs para desacoplar o que a API recebe do que é persistido no banco.
- Modelagem de relacionamento 1:N entre entidades com Entity Framework Core (Autor → Livros).
- Padronização de respostas da API com um objeto `ResponseModel<T>` genérico, incluindo tratamento de erros com try/catch nos services.

## Próximos passos

- [ ] Renomear o repositório/domínio para refletir melhor o escopo (Catálogo de Livros) ou expandir para um estoque genérico de produtos
- [ ] Adicionar testes automatizados
- [ ] Adicionar validação de dados nos DTOs (ex. Data Annotations)
- [ ] Adicionar autenticação/autorização
