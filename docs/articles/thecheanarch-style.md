# Estilo _The Clean Arch_

Antes de continuar, queremos estabelecer primeiro algumas recomendações sobre a codificação de soluções .NET no estilo _"The Clean Arch"_. Vamos falar de pequenos detalhes como: estrutura de diretórios, arquivos de configuração, manuseio de Data/Hora, escrever testes, e outros.

Conhecer esses detalhes lhe ajudará a se familiarizar e reconhecer projetos no estilo _"The Clean Arch"_. Então você pode encarar essas recomendações como parte da arquitetura, e compreende o _"Estilo The Clean Arch"_ de codificar.

## Estrutura de diretório

A primeira coisa a se fazer é organizar o diretório de solução para conter nosso código, e você precisa entender alguns detalhes.

> [!IMPORTANT]
> Quando falamos: **"solução"**, estamos nos referindo ao projeto de software (aquele que tem tipicamente um repositório que armazenamos no [GitHub](https://github.com) por exemplo). Temos os arquivos de projeto do .NET (`*.csproj`, `*.fsproj`, `*.vbproj`), a esses chamamos de **projeto** e as vezes _componente_. A **solução** sempre é o projeto geral do sofware, o repositório Git ou o diretório raiz que contém todo nosso código de software.

Essa é a estrutura de diretório para nossas soluções de software .NET:
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
  ├─ {Solution}.sln
  ├─ global.json
  └─ nuget.config
```

Ententendo:

* Arquivo de manifesto para ferramentas .NET `.config/dotnet-tools.json`
* Diretório de documentação da solução `docs/`
* Diretório de programas de engenharia `eng/`
* Diretório de amostras `samples/`
* Diretório de código de componentes `src/`
* Diretório de testes de componentes `test/`
* Arquivo de configurações do editor `.editorconfig`
* Arquivo de definições [Git](https://git-scm.com) para ignorar arquivos
* Arquivo geral da solução `{Solution}.sln` (aqui o nome é o da sua solução)
* Arquivo com configurações globais .NET para a solução `global.json`
* Arquivo com configurações globais [NuGet](https://nuget.org) para a solução `nuget.config`

## Licença de software

A licença de software é expressa de duas formas distintas: Um arquivo `LICENSE` na raiz da solução que determina as regras de licenciamento, e cabeçalho de aviso de licença e direitos autorais nos arquivos de código.

Portanto:

* Toda solução _"The Clean Arch"_ deve conter um [arquivo `LICENSE`][LICENSE] na raiz da solução contendo as regras de licenciamento
* Todo arquivo de código deve conter um aviso de licença e direitos autorais como neste exemplo:
```c#
// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.
```

## Nomenclatura de componentes

O arquivo geral da solução deve ser nomeado com o nome do projeto de software, porém sem espaços ou caracteres especiais, e obedecendo ao padrão [UpperCamelCase][CAMELCASE]. Exemplo: Para um projeto chamado _"Árvore Genealógica"_ o arquivo de solução seria `ArvoreGenealogica.sln`.

> [!NOTE]
> O nome do projeto de software pode ser um componente de um projeto maior, ou seja, um subprojeto.
> Nestes casos é recomendado usar a separação de nome de módulo ou companhia do submódulo por um ponto. Ex: `MyProject.MySubproject`.

O componente (projeto .NET) principal da solução (a camada de aplicação) leva o mesmo nome do arquivo geral da solução, pois representa a aplicação em si. Ex: `ArvoreGenealogica.csproj` para um projeto C#.

Os demais componentes devem ser nomeados com o nome da solução como prefixo, seguido do nome do componente (que muitas vezes reflete a camada do sofware codificada).

Exemplos:
* `ArvoreGenealogica.Domain`
* `ArvoreGenealogica.WebApi`
* `ArvoreGenealogica.Cli`
* `ArvoreGenealogica.DataStorage`
* `ArvoreGenealogica.GitHubApiGateway`

> [!IMPORTANT]
> Ambos os arquivos de componente devem residir no subdiretório `src/`.

Os arquivos de teste devem levar o mesmo nome do componente alvo mais o sufixo `Tests`.

Exemplos:
* `ArvoreGenealogica.DomainTests`
* `ArvoreGenealogica.WebApiTests`
* `ArvoreGenealogica.CliTests`
* `ArvoreGenealogica.DataStorageTests`
* `ArvoreGenealogica.GitHubApiGatewayTests`

> [!IMPORTANT]
> Ambos os arquivos de testes devem residir no subdiretório `test/`.

Nos próximos passos você verá ainda mais alguns detalhes sobre nosso estilo de codificação.

<!-- links -->
[LICENSE]: https://github.com/Hibex-Solutions/TheCleanArch/blob/main/LICENSE
[CAMELCASE]: https://en.wikipedia.org/wiki/Camel_case