# 4. Habilite Teste Unitário

Você aprenderá mais sobre testes unitários e como nós recomendamos seu uso nas seções de _Engineering Guidelines_. Por hora vamos criar os projetos de teste para 3 componentes: nossa camada de aplicação, domínio e API Web. Este é o mínimo recomendado para cobertura de teste em nossos softwares.

> [!TIP]
> Nós recomendamos o framework de testes [xUnit.net][XUNIT] com biblioteca [Moq][MOQ] para [objetos mock][MOCK_OBJECTS] de dependências, e [Report Generator][REPORT_GENERATOR] para relatórios de cobertura de código.

Crie os projetos de teste de componente.

```sh
dotnet new xunit -n AgeTests -o test/AgeTests
dotnet new xunit -n Age.DomainTests -o test/Age.DomainTests
dotnet new xunit -n Age.WebApiTests -o test/Age.WebApiTests
```

Referencie a dependência da biblioteca [Moq][MOQ].

```sh
dotnet add test/AgeTests/AgeTests.csproj package Moq
dotnet add test/Age.DomainTests/Age.DomainTests.csproj package Moq
dotnet add test/Age.WebApiTests/Age.WebApiTests.csproj package Moq
```

Adicione cada alvo do teste como dependência.

```sh
dotnet add test/AgeTests/AgeTests.csproj reference src/Age/Age.csproj
dotnet add test/Age.DomainTests/Age.DomainTests.csproj reference src/Age.Domain/Age.Domain.csproj
dotnet add test/Age.WebApiTests/Age.WebApiTests.csproj reference src/Age.WebApi/Age.WebApi.csproj
```

Adicione os novos projetos de teste à solução.

```sh
dotnet sln Age.sln add test/AgeTests/AgeTests.csproj
dotnet sln Age.sln add test/Age.DomainTests/Age.DomainTests.csproj
dotnet sln Age.sln add test/Age.WebApiTests/Age.WebApiTests.csproj
```

Semelhante ao que fizemos em [Habilite _The Clean Arch_](enable-thecleanarch.md), quando editamos o arquivo `.csproj` e adicionamos alguns novos arquivos com código padrão, faremos aqui.

Primeiro altere todos seus arquivos `.csproj` dentro de `/test/` removendo as propriedades `ImplicitUsings`, `Nullable`, `IsPackable` e `IsTestProject`, e caso exista a seção com `<Using Include="Xunit" />` (isso depende da versão do template), remova também.

> [!NOTE]
> Essas propriedades estarão em nossos arquivos padrões que criaremos em seguida.

```diff
  <PropertyGroup>
     <TargetFramework>net8.0</TargetFramework>
-    <ImplicitUsings>enable</ImplicitUsings>
-    <Nullable>enable</Nullable>
-    <IsPackable>false</IsPackable>
-    <IsTestProject>true</IsTestProject>
  </PropertyGroup>
- <ItemGroup>
-    <Using Include="Xunit" />
- </ItemGroup>
```

Crie o arquivo `test/Directory.build.props` com as propriedades comuns em todos os projetos de teste seguinte conteúdo:

```xml?highlight=8,9
<Project>
    <PropertyGroup>
        <Product>Age</Product>
        <AnalysisLevel>8.0-recommended</AnalysisLevel>
        <EnforceCodeStyleInBuild>true</EnforceCodeStyleInBuild>
        <ImplicitUsings>disable</ImplicitUsings>
        <Nullable>enable</Nullable>
        <IsPackable>false</IsPackable>
        <IsTestProject>true</IsTestProject>
        <!-- Informe aqui todas as outras propriedades que queira
             e sejam comuns a todos os componentes -->
    </PropertyGroup>
</Project>
```

Crie um arquivo `Usings.cs` em cada projeto de teste com seguinte conteúdo.

```cs
global using Xunit;
```

> [!TIP]
> Percebeu que as propriedades que removemos de nossos arquivos de projeto `.csproj` estão agora nesses arquivos com propriedades e códigos padrões?

Porfim instale a ferramenta [Report Generator][REPORT_GENERATOR] como dependência da solução.

```sh
dotnet tool install dotnet-reportgenerator-globaltool
```

Para saber mais sobre o uso da ferramenta Report Generator use `dotnet reportgenerator -h` ou acesse o [site da ferramenta][REPORT_GENERATOR].

Pronto! Agora você está habilitado para usar [TDD][TDD] no seu dia a dia. Inclusive essa é outra recomendação _The Clean Arch_.

<!-- links -->
[XUNIT]: https://xunit.net
[MOQ]: https://github.com/devlooped/moq
[TDD]: https://pt.wikipedia.org/wiki/Test-driven_development
[MOCK_OBJECTS]: https://en.wikipedia.org/wiki/Mock_object
[REPORT_GENERATOR]: https://reportgenerator.io