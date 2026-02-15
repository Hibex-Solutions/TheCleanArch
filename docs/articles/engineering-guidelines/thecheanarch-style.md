# Estilo _The Clean Arch_

Antes de continuar, queremos estabelecer primeiro algumas recomendações sobre a codificação de soluções [.NET][DOTNET] no estilo _"The Clean Arch"_. Vamos falar de pequenos detalhes como: estrutura de diretórios, arquivos de configuração, manuseio de Data/Hora, escrever testes, e outros. Alguns você já conhece se passou pelo [guia de início rápido](../getting-started/create-solution-structure.md), mas queremos consolidá-los nessa seção.

Conhecer esses detalhes lhe ajudará a se familiarizar e reconhecer projetos no estilo _"The Clean Arch"_. Então você pode encarar essas recomendações como parte da arquitetura, e compreende o _"Estilo The Clean Arch"_ de codificar.

## Estrutura de diretório

A primeira coisa a se fazer é organizar o diretório de solução para conter nosso código, e você precisa entender alguns detalhes.

> [!IMPORTANT]
> Quando falamos: **"solução"**, estamos nos referindo ao projeto de software (aquele que tem tipicamente um repositório que armazenamos no [GitHub](https://github.com) por exemplo). Temos os arquivos de projeto do [.NET][DOTNET] (`*.csproj`, `*.fsproj`, `*.vbproj`), a esses chamamos de **projeto** e as vezes _componente_. A **solução** sempre é o projeto geral do sofware, o repositório Git ou o diretório raiz que contém todo nosso código de software.

Essa é a estrutura de diretório para nossas soluções de software [.NET][DOTNET]:
```
./solution-folder
  ├─ .config/
  │  └─ dotnet-tools.json
  ├─ docs/
  ├─ eng/
  ├─ samples/
  ├─ src/
  ├─ test/
  ├─ .editorconfig
  ├─ .gitignore
  ├─ {Solution}.slnx
  ├─ global.json
  ├─ nuget.config
  └─ omnisharp.json
```

Ententendo:

* Arquivo de manifesto para ferramentas [.NET][DOTNET] `.config/dotnet-tools.json`
* Diretório de documentação da solução `docs/`
* Diretório de programas de engenharia `eng/`
* Diretório de amostras `samples/`
* Diretório de código de componentes `src/`
* Diretório de testes de componentes `test/`
* Arquivo de configurações do editor `.editorconfig`
* Arquivo de definições [Git](https://git-scm.com) para ignorar arquivos `.gitignore`
* Arquivo geral da solução `{Solution}.slnx` (aqui o nome é o da sua solução)
* Arquivo com configurações globais [.NET][DOTNET] para a solução `global.json`
* Arquivo com configurações globais [NuGet](https://nuget.org) para a solução `nuget.config`
* Arquivo de definições do [Omnisharp][OMNISHARP] `omnisharp.json`

## Licença de software

A licença de software é expressa de duas formas distintas:

1. Um arquivo `LICENSE` na raiz da solução que determina as regras de licenciamento, e
2. Cabeçalho de aviso de licença e direitos autorais nos arquivos de código.

Portanto, em uma solução nos padrões _The Clean Arch_, temos:

* Todo arquivo de código deve conter um aviso de licença e direitos autorais como neste exemplo:
```cs
// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch. Licensed under the Apache version 2.0: LICENSE file.
```
* Opcionalmente contém um [arquivo `LICENSE`][LICENSE] na raiz da solução contendo as regras de licenciamento

## Nomenclatura de componentes

O arquivo geral da solução deve ser nomeado com o nome do projeto de software, porém sem espaços ou caracteres especiais, e obedecendo ao padrão [UpperCamelCase][CAMELCASE].

Exemplo: Para um projeto de software chamado _"Árvore Genealógica"_, o arquivo de solução seria `ArvoreGenealogica.slnx`.

> [!NOTE]
> O próprio projeto de software pode ser apenas um módulo de um projeto maior, ou seja, um subprojeto.
> Ou ainda, pode ser uma companhia (empresa, grupo ou comunidade) que produz vários projetos de software relacionados.
> Nestes casos é recomendado usar o nome do projeto principal ou da companhia como prefixo do nome do projeto.
> Separe o prefixo do nome com um ponto. Ex: `MyProject.MySubproject.slnx` ou `MyCompany.MyProject.slnx`.

Os componentes devem ser nomeados com o nome da solução como prefixo, seguido do nome do componente (que muitas vezes reflete a camada do sofware codificada), como `[Prefixo].Componente`.

Exemplos:
* `ArvoreGenealogica.Business.Entities`
* `ArvoreGenealogica.Business.UseCases`
* `ArvoreGenealogica.InterfaceAdapters.UserInterfaces.WebApi`
* `ArvoreGenealogica.InterfaceAdapters.UserInterfaces.CliApp`
* `ArvoreGenealogica.InterfaceAdapters.DataAccess.MongoDB`
* `ArvoreGenealogica.InterfaceAdapters.Gateways.GitHub`

> [!IMPORTANT]
> Os componentes devem residir no subdiretório `src/`.

Os arquivos de teste devem levar o mesmo nome do componente alvo mais o sufixo `Tests`, porém sem um ponto o separando do nome, como `[ComponenteAlvo]Tests`.

Exemplos:
* `ArvoreGenealogica.Business.UseCasesTests`
* `ArvoreGenealogica.Business.EntitiesTests`
* `ArvoreGenealogica.InterfaceAdapters.UserInterfaces.WebApiTests`
* `ArvoreGenealogica.InterfaceAdapters.UserInterfaces.CliAppTests`
* `ArvoreGenealogica.InterfaceAdapters.DataAccess.MongoDBTests`
* `ArvoreGenealogica.InterfaceAdapters.Gateways.GitHubTests`

> [!IMPORTANT]
> Os testes de componentes devem residir no subdiretório `test/`.

## Editores e IDEs

Nenhum projeto de software deve depender de qualquer recurso que seja exclusivo de um editor ou IDE. Ao invés disso use técnicas e padrões que possam ser compartilhados entre esses editores e IDEs.

> [!NOTE]
> Saiba mais em [Habilite editores](../getting-started/enable-code-editors.md).

Nos próximos passos você verá ainda mais alguns detalhes sobre nosso estilo de codificação.

<!-- links -->
[LICENSE]: https://github.com/Hibex-Solutions/TheCleanArch/blob/main/LICENSE
[CAMELCASE]: https://en.wikipedia.org/wiki/Camel_case
[OMNISHARP]: https://www.omnisharp.net/
[DOTNET]: https://dot.net