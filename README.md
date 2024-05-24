![](docs/assets/CleanArchBanner.png)

![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/Hibex-Solutions/TheCleanArch/ci.yaml?style=flat-square&logo=github&label=CI) ![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/Hibex-Solutions/TheCleanArch/cd.yaml?style=flat-square&logo=github&label=CD)

Mais uma implementação da definição de _"Arquitetura Limpa"_ conforme escrito por _Robert C. Martin (Uncle Bob)_ em seu artigo _"The Clean Architecture"_. Neste caso, implementamos para .NET.

* [Licenciado sob _Apache License 2.0_](LICENSE)
* [Código de conduta da comunidade](CODE_OF_CONDUCT.md)
* [Como contribuir?](CONTRIBUTING.md)

## Requisitos mínimos

* [.NET 6](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0)
* [C# 10](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10)

## Instruções de desenvolvimento

Ao iniciar:
```sh
$ dotnet restore
$ dotnet tool restore
```

Para exibir informações de versão:
```sh
$ dotnet gitversion
```