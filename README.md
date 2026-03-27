# 🪒 Barbearia API - Sistema de Agendamento Profissional

Este projeto marca minha evolução no ecossistema .NET, saindo de aplicações em modo Console para o desenvolvimento de uma **Web API robusta** voltada a resolver problemas reais de gestão de pequenos negócios.

## 🚀 Evolução Técnica: Do Terminal para o Mundo Real
Nesta fase inicial, o foco foi a transição da lógica linear de terminal para uma arquitetura orientada a serviços e persistência de dados.

### Principais Aprendizados:
*   **Arquitetura Web API:** Substituí o `Console.ReadLine()` e `Console.WriteLine()` por controladores (`Controllers`) e endpoints HTTP (`GET`, `POST`).
*   **Mapeamento Objeto-Relacional (ORM):** Implementei o **Entity Framework Core**, permitindo que classes C# gerenciem tabelas SQL de forma automatizada (**Code-First**).
*   **Persistência de Dados:** Migrei de listas temporárias em memória para um banco de dados real, utilizando **Migrations** para versionar a estrutura das tabelas.
*   **Injeção de Dependência:** Configurei o ciclo de vida do `AppDbContext` no `Program.cs`, seguindo padrões de mercado para aplicações escaláveis.

## 🏗️ Modelagem do Domínio (Database)
Estruturei as entidades fundamentais do negócio na pasta `/Models`:

1.  **Cliente (`Client`)**: Gestão de usuários (Nome, Telefone, Email).
2.  **Serviço (`Service`)**: Catálogo com Preço e Duração (Corte, Barba, Sobrancelha).
3.  **Agendamento (`Appointment`)**: O "coração" do sistema, relacionando Clientes e Serviços com data e hora.

## 📡 Endpoints Implementados (Módulo Cliente)
Desenvolvi o `ClientesController` com as seguintes funcionalidades profissionais:

*   `GET /api/clientes`: Recupera a lista completa de clientes cadastrados.
*   `GET /api/clientes/{id}`: Busca detalhada por ID com tratamento de erro `404 Not Found`.
*   **Documentação Interativa**: Implementação do **Scalar** (`/scalar/v1`) para testes de API em interface visual moderna.

## 🛠️ Tecnologias e Ferramentas
*   **Linguagem:** C# / .NET 10.0
*   **Framework:** ASP.NET Core Web API
*   **Banco de Dados:** SQL Server / SQLite
*   **ORM:** Entity Framework Core
*   **Documentação:** Scalar (OpenAPI 3.0)

## 🔜 Próximos Passos
- [ ] Implementar CRUD completo de **Serviços**.
- [ ] Desenvolver a lógica de **Agendamentos** com validação de disponibilidade.
- [ ] Adicionar Regra de Negócio: Impedir agendamentos duplicados no mesmo horário.

---
*Projeto desenvolvido para portfólio técnico *
