![The Clean Arch for .NET](docs/images/TheCleanArchBanner.png)

![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/Hibex-Solutions/TheCleanArch/ci.yaml?style=flat-square&logo=github&label=CI) ![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/Hibex-Solutions/TheCleanArch/cd.yaml?style=flat-square&logo=github&label=CD) ![GitHub Tag](https://img.shields.io/github/v/tag/Hibex-Solutions/TheCleanArch?include_prereleases&style=flat-square&logo=github) ![GitHub License](https://img.shields.io/github/license/Hibex-Solutions/TheCleanArch?style=flat-square&logo=apache) ![GitHub commit activity](https://img.shields.io/github/commit-activity/y/Hibex-Solutions/TheCleanArch?style=flat-square&logo=github&label=commits)



Mais uma implementação da definição de _"Arquitetura Limpa"_ conforme escrito por _Robert C. Martin (Uncle Bob)_ em seu artigo _"The Clean Architecture"_. Neste caso, implementamos para .NET.

* [Licenciado sob _Apache License 2.0_](LICENSE)
* [Código de conduta da comunidade](CODE_OF_CONDUCT.md)
* [Como contribuir?](CONTRIBUTING.md)

| Pacote | Versão |
| ------ | ----------------- |
| TheCleanArch.Core  | ![NuGet Version](https://img.shields.io/nuget/v/TheCleanArch.Core?style=flat-square&logo=nuget) ![NuGet Version](https://img.shields.io/nuget/vpre/TheCleanArch.Core?style=flat-square&logo=nuget) |
| TheCleanArch.Enterprise  | ![NuGet Version](https://img.shields.io/nuget/v/TheCleanArch.Enterprise?style=flat-square&logo=nuget) ![NuGet Version](https://img.shields.io/nuget/vpre/TheCleanArch.Enterprise?style=flat-square&logo=nuget) |
| TheCleanArch.Application  | ![NuGet Version](https://img.shields.io/nuget/v/TheCleanArch.Application?style=flat-square&logo=nuget) ![NuGet Version](https://img.shields.io/nuget/vpre/TheCleanArch.Application?style=flat-square&logo=nuget) |
| TheCleanArch.InterfaceAdapter  | ![NuGet Version](https://img.shields.io/nuget/v/TheCleanArch.InterfaceAdapter?style=flat-square&logo=nuget) ![NuGet Version](https://img.shields.io/nuget/vpre/TheCleanArch.InterfaceAdapter?style=flat-square&logo=nuget) |

# Início rápido

```sh
# 1. Instale os templates
dotnet new install TheCleanArch.Templates

# 2. Crie sua solução
dotnet new tca-basic-solution -n Solucao -o ./solucao
```

Pronto. Agora é só "codar" 😄!