# Decisões arquiteturais

## Explícito é melhor que implícito

Aprendemos que o que é implicito depende muito da versão e momento de cada
ferrramenta ou comunidade. O que é padrão em um .NET SDK 3.1 pode já não ser mais
em um .NET SDK 10.0. E como manter o sistema atualizado também é uma responsabilidade
de quem desenvolve, preferimos deixar claro as decisões e usar o mínimo possível
de opções _implícitas_. Com o tempo isso salva vidas.

- Sempre usar o arquivo `global.json` para deixar explícita a versão do SDK
- Sempre anotamos em cada componente (projeto) a que camada pertence, com `ArchLayerId` no arquivo `AssemblyInfo.cs`
- Desabilitamos no projeto a propriedade `<ImplicitUsings>` e usamos `Usings.cs` para deixar excplícito os _namespaces_ usados globalmente.
- Sempre usar o arquivo `Directory.Build.props` para explicitar o que é comum para todos os projetos da solução

## Usamos o padrão "Domain Driven Design" na camada Entities

TODO ...

## Usamos o padrão "Ports and Adapters" na camada UseCases

TODO ...
