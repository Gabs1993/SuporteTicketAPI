# 🚀 Support Ticket API

---

## 📌 Visão Geral

Esta aplicação foi desenvolvida como parte de um desafio técnico com o objetivo de implementar um sistema simples de gerenciamento de chamados (tickets) de suporte interno.

A solução permite que usuários criem, visualizem, atualizem e removam tickets, enquanto a equipe de suporte pode acompanhar o status de cada solicitação.

---

## 🧱 Arquitetura

O projeto foi estruturado seguindo princípios de separação de responsabilidades, inspirado em **Clean Architecture**, dividido em camadas:

* **Domain** → Entidades e regras de negócio
* **Application** → Serviços, DTOs e interfaces
* **Infrastructure (Infra.Data)** → Persistência de dados (EF Core)
* **API (SupportTicketApiWeb)** → Camada de apresentação (Controllers)

Essa abordagem facilita manutenção, testes e evolução do sistema.

---

## 🛠️ Tecnologias Utilizadas

* .NET 8
* Entity Framework Core
* SQL Server
* Docker / Docker Compose
* xUnit + Moq + FluentAssertions

---

## ⚙️ Funcionalidades

* ✅ Criar um ticket
* ✅ Listar tickets (com paginação)
* ✅ Buscar ticket por ID
* ✅ Atualizar dados do ticket
* ✅ Atualizar status do ticket
* ✅ Deletar ticket
* ✅ Tratamento global de erros
* ✅ Testes unitários para regras de negócio

---

## 📊 Paginação

A listagem de tickets suporta paginação para melhor performance e controle de dados:

```http
GET /tickets?page=1&pageSize=10
```

### Exemplo de resposta:

```json
{
  "data": [...],
  "totalItems": 25,
  "page": 1,
  "pageSize": 10
}
```

---

## 🔄 Regras de Negócio

O fluxo de status dos tickets foi modelado da seguinte forma:

* **Open** → Ticket criado
* **Done** → Ticket concluído

Inicialmente, foi adicionado que, antes de ir para Done, era obrigatório passar por InProgress, mas, às vezes, acontece de um ticket ser extremamente muito fácil ou outra pessoa acabou de finalizar o ticket, só não o concluiu ainda. Por esse motivo, eu voltei e deixei somente de Open -> Done.

### Implementações futuras

* Realizar uma camada de autenticação e autorização
* Logs estruturados para monitoramento da aplicação
* Melhorar a regra de negocio do ticket

---

## 🛡️ Tratamento de Erros

A aplicação utiliza um middleware global de exceções, garantindo respostas padronizadas:

```json
{
  "message": "Ticket não encontrado",
  "statusCode": 404
}
```

---

## 🐳 Como Executar com Docker

### Pré-requisitos

* Docker instalado

### Passos

```bash
docker-compose up --build
```

A aplicação estará disponível em:

👉 http://localhost:5000/swagger

---

## 💻 Execução Local

### Backend

```bash
dotnet run
```

### Banco de dados (LocalDB)

Certifique-se de que o SQL Server LocalDB está disponível.

---

## 🧪 Testes

Para executar os testes:

```bash
dotnet test
```

### Cobertura dos testes:

* Regras de negócio da entidade Ticket
* Comportamento do serviço

---

## 📌 Decisões Técnicas

* Arquitetura em camadas para organização e escalabilidade
* Uso de DTOs para desacoplamento entre camadas
* Paginação para melhorar performance
* Middleware de exceções para padronização de erros
* Docker para facilitar execução e portabilidade
* Testes unitários para garantir confiabilidade

---

## 👨‍💻 Autor

**Gabriel Conceição dos Santos**
