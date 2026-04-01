# 4. Habilite Teste Unitário

Você aprenderá mais sobre testes unitários e como nós recomendamos seu uso nas seções de _Engineering Guidelines_. Por hora vamos criar os projetos de teste unitário para dois componentes: nossa camada de aplicação e domínio. Este é o mínimo recomendado para cobertura de teste em nossos softwares.

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
> usaremos teste de integração, que veremos em outro momento. 

```sh
mkdir test/Business

dotnet new console -n Age.Business.EntitiesUnitTests -o test/Business/EntitiesUnitTests
dotnet new console -n Age.Business.UseCasesUnitTests -o test/Business/UseCasesUnitTests
```

Referencie a dependência das bibliotecas [TUnit][TUNIT] e [Moq][MOQ], para teste
e _moking_ respectivamente.

```sh
dotnet add test/Business/EntitiesUnitTests/Age.Business.EntitiesUnitTests.csproj package TUnit
dotnet add test/Business/EntitiesUnitTests/Age.Business.EntitiesUnitTests.csproj package Moq

dotnet add test/Business/UseCasesUnitTests/Age.Business.UseCasesUnitTests.csproj package TUnit
dotnet add test/Business/UseCasesUnitTests/Age.Business.UseCasesUnitTests.csproj package Moq
```

Remova o código `Program.cs` das aplicações, porque [TUnit][TUNIT] já vem com
a implementação de código principal.

```sh
rm test/Business/EntitiesUnitTests/Program.cs
rm test/Business/UseCasesUnitTests/Program.cs
```

Adicione cada alvo do teste como dependência.

```sh
dotnet add test/Business/EntitiesUnitTests/Age.Business.EntitiesUnitTests.csproj reference src/Business/Entities/Age.Business.Entities.csproj

dotnet add test/Business/UseCasesUnitTests/Age.Business.UseCasesUnitTests.csproj reference src/Business/UseCases/Age.Business.UseCases.csproj
```

Adicione os novos projetos de teste à solução.

```sh
dotnet sln add test/Business/EntitiesUnitTests/Age.Business.EntitiesUnitTests.csproj
dotnet sln add test/Business/UseCasesUnitTests/Age.Business.UseCasesUnitTests.csproj
```

Semelhante ao que fizemos em [Habilite _The Clean Arch_](enable-thecleanarch.md), quando editamos o arquivo `.csproj` e adicionamos alguns novos arquivos com código padrão, faremos aqui.

Primeiro altere todos seus arquivos `.csproj` dentro de `/test/` removendo as propriedades `ImplicitUsings` e `Nullable`.

> [!NOTE]
> Essas propriedades estarão em nossos arquivos padrões que criaremos em seguida.

```diff
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
-   <ImplicitUsings>enable</ImplicitUsings>
-   <Nullable>enable</Nullable>
  </PropertyGroup>
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

Pronto! Agora você está habilitado para usar [TDD][TDD] no seu dia a dia. Inclusive essa é outra recomendação _The Clean Arch_.

<!-- links -->
[TUNIT]: https://tunit.dev
[MOQ]: https://github.com/devlooped/moq
[TDD]: https://pt.wikipedia.org/wiki/Test-driven_development
[MOCK_OBJECTS]: https://en.wikipedia.org/wiki/Mock_object
[REPORT_GENERATOR]: https://reportgenerator.io
[MTP]: https://learn.microsoft.com/pt-pt/dotnet/core/testing/microsoft-testing-platform-intro?tabs=dotnetcli
