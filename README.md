# API de taxas de câmbio

Projeto de estudo em C# e ASP.NET Core 8. Informe uma moeda-base para consultar suas taxas de câmbio. A API obtém os dados da ExchangeRate-API via `HttpClient` e devolve a moeda-base e um dicionário de taxas.

## Executar localmente

Com o SDK do .NET 8 instalado, execute na raiz do repositório:

```bash
dotnet run --launch-profile http
```

Abra a [documentação Swagger](http://localhost:5181/swagger) ou consulte as taxas do dólar em outro terminal:

```bash
curl http://localhost:5181/api/v1/currency/USD
```

A consulta precisa de acesso à internet. Na resposta, `base` identifica a moeda de referência e `rates` associa cada código de moeda à taxa de uma unidade da base. Por exemplo, para a base USD, `rates.BRL` representa o valor de um dólar em reais.

## Como a consulta funciona

1. O [controlador v1](controller/CurrencyV1Controller.cs) recebe `GET /api/v1/currency/{baseCurrency}` e converte o código da moeda para maiúsculas.
2. O [serviço de câmbio](services/CurrencyService.cs) consulta o provedor, verifica o status HTTP e desserializa a resposta.
3. O [modelo de resposta](models/CurrencyApiResponse.cs) define os campos devolvidos ao cliente.

## Teste de integração

Execute `dotnet test system.sln` na raiz. O teste chama a rota v1 pela interface HTTP da aplicação, substitui o provedor externo por uma resposta fixa e verifica a moeda-base e a taxa devolvidas. O mesmo teste está configurado para rodar em pull requests e em pushes na `main`.
