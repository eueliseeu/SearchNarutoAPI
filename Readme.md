# SearchNarutoAPI

Atividade da faculdade: aplicação **Blazor WebAssembly** (.NET 10) que consome a [Dattebayo API](https://api-dattebayo.vercel.app/docs) e exibe os dados dos personagens de Naruto: nome, imagem, clã e afiliação, jutsus e patente ninja.

## Informações da atividade

| Campo       | Informação                                   |
|-------------|----------------------------------------------|
| Instituição | Anima Educação                               |
| Matéria     | Desenvolvimento Web                          |
| Professor   | Daniel Henrique Matos de Paiva               |
| Autor       | Eliseu Pereira da Silva                      |
| RA          | 124220479                                    |

## Endpoints utilizados

- Lista paginada: `https://dattebayo-api.onrender.com/characters?page={page}`
- Busca por nome: `https://dattebayo-api.onrender.com/characters?page={page}&name={nome}`

## Como executar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download) ou superior.

```bash
git clone <url-do-repositorio>
cd SearchNarutoAPI
dotnet run
```

Depois, abra no navegador a URL exibida no terminal. A API fica hospedada em um plano gratuito, então a primeira requisição pode levar alguns segundos.

## Estrutura do projeto

```
SearchNarutoAPI/
├── Converters/  # Leitura de campos da API que variam entre texto, lista e objeto
├── Models/      # Classes que representam o JSON da API
├── Services/    # Acesso HTTP à API (interface + implementação)
├── Pages/       # Página Home (marcação, code-behind e CSS)
├── Layout/      # Layout principal
└── Program.cs   # Configuração e injeção de dependência
```
