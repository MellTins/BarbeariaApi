# 🪒 Barbearia API - Sistema de Agendamento Profissional

![Status do Projeto](https://img.shields.io)
![.NET Version](https://img.shields.io)

Este projeto marca minha transição definitiva de aplicações **Console** para o desenvolvimento de **Web APIs industriais**. Desenvolvi um sistema de back-end completo para gestão de barbearias, focado em persistência de dados e regras de negócio complexas.

## 📸 Demonstração da Interface (Scalar)
> [!TIP]
> (<img width="891" height="672" alt="Captura de tela 2026-04-02 103739" src="https://github.com/user-attachments/assets/007f88dc-df0b-4691-b6b8-174ab06662ba" />
)
>

## 🚀 Evolução Técnica: Do Terminal para o Back-end Real
Sair da lógica linear de console exigiu o domínio de uma stack moderna. Neste projeto, implementei:

### ⚙️ Arquitetura e Persistência
*   **Entity Framework Core (Code-First):** Toda a estrutura do banco de dados foi gerada a partir de classes C#.
*   **Gerenciamento de Migrations:** Utilizei o histórico de migrations para versionar o banco de dados, incluindo ajustes de precisão decimal financeira.
*   **Relacionamentos SQL:** Implementei chaves estrangeiras e *Navigation Properties* para conectar Clientes, Serviços e Agendamentos.

### 🧠 Regras de Negócio Implementadas
*   **Validação de Concorrência (Agendamentos):** Utilizei o método `.Any()` do LINQ para impedir que dois clientes ocupem o mesmo horário no banco de dados.
*   **Eager Loading (JOINs):** Uso do método `.Include()` para retornar objetos completos (ex: ver o nome do cliente dentro do agendamento) em vez de apenas IDs.
*   **Tratamento de Ciclos JSON:** Configuração de serialização no `Program.cs` para evitar loops infinitos em relacionamentos bidimensionais.

## 📡 Endpoints Principais

### Clientes (`/api/clientes`)
*   `GET`: Lista todos os clientes.
*   `POST`: Cadastro com validação de dados.
*   `PUT/DELETE`: Gestão completa do ciclo de vida do registro.

### Serviços (`/api/servicos`)
*   Catálogo com **precisão decimal (18,2)** para valores monetários.
*   Definição de duração de cada procedimento.

### Agendamentos (`/api/agendamentos`)
*   **O coração do sistema:** Une Cliente e Serviço a uma Data/Hora.
*   Retorno enriquecido com dados das tabelas relacionadas.

## 🛠️ Tecnologias
*   **Linguagem:** C# (.NET 10)
*   **Framework:** ASP.NET Core Web API
*   **ORM:** Entity Framework Core
*   **Documentação:** Scalar (OpenAPI 3.0)
*   **Banco de Dados:** SQL Server / SQLite

---
**Desafio Superado:** "O maior aprendizado foi entender como o código C# se comunica com o motor do banco de dados e como garantir que os dados retornem limpos (sem nulos) para o front-end usando as ferramentas corretas do .NET."

**Desenvolvido por [Meliss Martins]** - Foco em Backend C#
