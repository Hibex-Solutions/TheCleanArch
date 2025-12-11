# 1. Crie a estrutura da solução

- Mudar global.json de 8.0 para 10.0
  dotnet new globaljson --sdk-version "10.0.100" --roll-forward feature

- Mudar nome da camada de aplicação, de Age para Age.Application
 dotnet new classlib -n Age.Application -o src/Age.Application

- Renomear camada de acesso a dados no exemplo de Age.InMemoryStorage para Age.DataAdapter
  dotnet new classlib -n Age.DataAdapter -o src/Age.DataAdapter

- Usar minimal APIs na camada de apresentação
  dotnet new webapi -minimal -f net10.0 -n Age.WebApi -o src/Age.WebApi

- Renomear dependências
  dotnet add src/Age.Application/Age.Application.csproj reference src/Age.Domain/Age.Domain.csproj
  dotnet add src/Age.DataAdapter/Age.DataAdapter.csproj reference src/Age.Application/Age.Application.csproj
  dotnet add src/Age.WebApi/Age.WebApi.csproj reference src/Age.DataAdapter/Age.DataAdapter.csproj
  dotnet add src/Age.WebApi/Age.WebApi.csproj reference src/Age.Application/Age.Application.csproj

- Atualiza formato do arquivo de soluções, e suas referências
  dotnet new sln -n Age -f slnx
  dotnet sln add src/Age.Domain/Age.Domain.csproj
  dotnet sln add src/Age.Application/Age.Application.csproj
  dotnet sln add src/Age.DataAdapter/Age.DataAdapter.csproj
  dotnet sln add src/Age.WebApi/Age.WebApi.csproj

- Atualizar exemplos de exibição de pastas (novos nomes)

# 2. Habilite The Clean Arch

- Atualizar pacotes ao incluir referências TheCleanArch
  dotnet add src/Age.Domain/Age.Domain.csproj package TheCleanArch.Enterprise --prerelease
  dotnet add src/Age.Application/Age.Application.csproj package TheCleanArch.Application --prerelease
  dotnet add src/Age.DataAdapter/Age.DataAdapter.csproj package TheCleanArch.InterfaceAdapter --prerelease
  dotnet add src/Age.WebApi/Age.WebApi.csproj package TheCleanArch.InterfaceAdapter --prerelease

- Atualizar referência da versão do SDK nos exemplos
  <TargetFramework>net10.0</TargetFramework> para csproj
  <AnalysisLevel>10.0-recommended</AnalysisLevel> para Directory.Build.props

- Atualizar nomes nos exemplos
  // File: src/Age.Application/AssemblyInfo.cs
  // File: src/Age.DataAdapter/AssemblyInfo.cs

- Atualizar exemplos de exibição de pastas (novos nomes)

# 3. Habilite editores

Nada muda

# 4. Habilite Teste Unitário

- Atualizar nome de projetos de teste
  dotnet new xunit -n Age.ApplicationTests -o test/Age.ApplicationTests
  dotnet new xunit -n Age.DomainTests -o test/Age.DomainTests
  dotnet new xunit -n Age.WebApiTests -o test/Age.WebApiTests

- Adicionar MTP no global.json
  Adicionar links na documentação:
  - https://devblogs.microsoft.com/dotnet/dotnet-test-with-mtp/
  - https://devblogs.microsoft.com/dotnet/announcing-dotnet-10/
  - https://learn.microsoft.com/pt-br/dotnet/core/tools/dotnet-test?tabs=dotnet-test-with-mtp
  - https://learn.microsoft.com/pt-pt/dotnet/core/testing/microsoft-testing-platform-intro?tabs=dotnetcli

- Atualizar referências a biblioteca Moq
  dotnet add test/Age.ApplicationTests/Age.ApplicationTests.csproj package Moq

- Atualizar referências entre os projetos
  dotnet add test/Age.ApplicationTests/Age.ApplicationTests.csproj reference src/Age.Application/Age.Application.csproj
  dotnet add test/Age.DomainTests/Age.DomainTests.csproj reference src/Age.Domain/Age.Domain.csproj
  dotnet add test/Age.WebApiTests/Age.WebApiTests.csproj reference src/Age.WebApi/Age.WebApi.csproj

- Atualizar referências na solução
  dotnet sln add test/Age.ApplicationTests/Age.ApplicationTests.csproj
  dotnet sln add test/Age.DomainTests/Age.DomainTests.csproj
  dotnet sln add test/Age.WebApiTests/Age.WebApiTests.csproj

- Atualizar referência da versão do SDK nos exemplos
  <TargetFramework>net10.0</TargetFramework> para csproj
  <AnalysisLevel>10.0-recommended</AnalysisLevel> para Directory.Build.props

- Criar arquivo test/Directory.Build.props
