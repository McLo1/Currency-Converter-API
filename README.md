📘 Currency Converter API — .NET 8
# 💱 Currency Converter API — .NET 8

Projeto de estudo desenvolvido em **.NET 8** com o objetivo de aprender **consumo de APIs externas**, organização de código backend, uso de **DTOs**, **Swagger** e **versionamento de API**.

A API consome uma API pública de câmbio, trata os dados e disponibiliza endpoints para **consulta e conversão de moedas**.

---

## 🎯 Objetivo

Aprender e praticar:

- Consumo de APIs externas com HttpClient
- Organização de projetos backend
- Uso de DTOs
- Versionamento de APIs
- Documentação com Swagger

---

## 🚀 Funcionalidades

### 🔹 API v1
- Endpoint simples para testes e versionamento.

### 🔹 API v2
- Consulta de taxas de câmbio.
- Conversão de valores entre moedas.

---

## 📌 Exemplo de uso

```http
GET /api/v2/currency/convert?from=USD&to=BRL&amount=100


Resposta:

{
  "from": "USD",
  "to": "BRL",
  "amount": 100,
  "rate": 5.02,
  "result": 502.00
}

🛠️ Tecnologias

.NET 8

ASP.NET Core Web API

Swagger

API Versioning

HttpClient

DTO Pattern

▶️ Como executar
dotnet restore
dotnet run


Swagger:

http://localhost:5181/swagger

📝 Observação

Projeto com foco em aprendizado e prática, podendo ser expandido futuramente com cache, autenticação, rate limit e outras melhorias.
