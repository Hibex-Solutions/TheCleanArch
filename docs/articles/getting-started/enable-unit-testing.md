# 4. Habilite Teste Unitário

Você aprenderá mais sobre testes unitários e como nós recomendamos seu uso nas seções de _Engineering Guidelines_. Por hora vamos criar os projetos de teste para 3 componentes: nossa camada de aplicação, domínio e API Web. Este é o mínimo recomendado para cobertura de teste em nossos softwares.

> [!TIP]
> Nós recomendamos [Microsoft.Testing.Platform][MTP], com framework de testes [TUnit][TUNIT], biblioteca [Moq][MOQ] para [objetos mock][MOCK_OBJECTS] de dependências, e [Report Generator][REPORT_GENERATOR] para relatórios de cobertura de código local.

Habilite o executor de testes MTP no arquivo `global.json`.

```diff
{
  "sdk": {
    "rollForward": "feature",
    "version": "10.0.100"
  },
+  "test": {
+    "runner": "Microsoft.Testing.Platform"
+  }
}
```

Crie os projetos de teste unitário para cada componente.

> [!IMPORTANT]
> No nosso exemplo apenas os componentes da camada de negócio farão parte de
> nossos testes. Acesso a banco e Web APIs ficarão de fora, porque nesses casos
> usaremos teste de integração, que revemos em outro momento. 

```sh
dotnet new console -n Age.ApplicationTests -o test/Age.ApplicationTests
dotnet new console -n Age.DomainTests -o test/Age.DomainTests
```

Referencie a dependência das bibliotecas [TUnit][TUNIT] e [Moq][MOQ], para teste
e _moking_ respectivamente.

```sh
dotnet add test/Age.ApplicationTests/Age.ApplicationTests.csproj package TUnit Moq
dotnet add test/Age.DomainTests/Age.DomainTests.csproj package TUnit Moq
```

Remova o código `Program.cs` das aplicações, porque [TUnit][TUNIT] já vem com
a implementação de código principal.

```sh
rm test/Age.ApplicationTests/Program.cs
rm test/Age.DomainTests/Program.cs
```

Adicione cada alvo do teste como dependência.

```sh
dotnet add test/Age.ApplicationTests/Age.ApplicationTests.csproj reference src/Age.Application/Age.Application.csproj
dotnet add test/Age.DomainTests/Age.DomainTests.csproj reference src/Age.Domain/Age.Domain.csproj
```

Adicione os novos projetos de teste à solução.

```sh
dotnet sln add test/Age.ApplicationTests/Age.ApplicationTests.csproj
dotnet sln add test/Age.DomainTests/Age.DomainTests.csproj
```

Semelhante ao que fizemos em [Habilite _The Clean Arch_](enable-thecleanarch.md), quando editamos o arquivo `.csproj` e adicionamos alguns novos arquivos com código padrão, faremos aqui.

Primeiro altere todos seus arquivos `.csproj` dentro de `/test/` removendo as propriedades `ImplicitUsings` e `Nullable`.

> [!NOTE]
> Essas propriedades estarão em nossos arquivos padrões que criaremos em seguida.

```diff
  <PropertyGroup>
-    <ImplicitUsings>enable</ImplicitUsings>
-    <Nullable>enable</Nullable>
     <OutputType>Exe</OutputType>
     <TargetFramework>net10.0</TargetFramework>
  </PropertyGroup>
```

Crie o arquivo `test/Directory.Build.props` com as propriedades comuns em todos os projetos de teste seguinte conteúdo:

```xml?highlight=8,9
<Project>
    <PropertyGroup>
        <Product>Age</Product>
        <AnalysisLevel>10.0-recommended</AnalysisLevel>
        <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
        <ImplicitUsings>disable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <!-- Informe aqui todas as outras propriedades que queira
             e sejam comuns a todos os componentes -->
    </PropertyGroup>
</Project>
```

Crie um arquivo `Usings.cs` em cada projeto de teste com seguinte conteúdo.

```cs
global using System;
global using System.Threading.Tasks;
global using System.Collections.Generic;

global using TUnit.Core;
global using TUnit.Core.Interfaces;
global using TUnit.Assertions;
global using TUnit.Assertions.Extensions;

global using Moq;
```

> [!TIP]
> Percebeu que as propriedades que removemos de nossos arquivos de projeto `.csproj` estão agora nesses arquivos com propriedades e códigos padrões?

Porfim instale a ferramenta [Report Generator][REPORT_GENERATOR] como dependência da solução.

```sh
dotnet tool install dotnet-reportgenerator-globaltool
```

Para saber mais sobre o uso da ferramenta _Report Generator_ use `dotnet reportgenerator -h` ou acesse o [site da ferramenta][REPORT_GENERATOR].

Pronto! Agora você está habilitado para usar [TDD][TDD] no seu dia a dia. Inclusive essa é outra recomendação _The Clean Arch_.

<!-- links -->
[TUNIT]: https://tunit.dev
[MOQ]: https://github.com/devlooped/moq
[TDD]: https://pt.wikipedia.org/wiki/Test-driven_development
[MOCK_OBJECTS]: https://en.wikipedia.org/wiki/Mock_object
[REPORT_GENERATOR]: https://reportgenerator.io
[MTP]: https://learn.microsoft.com/pt-pt/dotnet/core/testing/microsoft-testing-platform-intro?tabs=dotnetcli