# CleanArch
 
 CleanArch pretende ser o núcleo para o desenvolvimento de projetos _dotNET_
 à partir do _NET6_, que aplicam os conceitos de arquitetura limpa, e nada mais.

# Notas para o desenvolvedor

* [Usamos .NET 6][NET6-LINK]
* [Usamos .NET SDK 6.0.408][NETSDK6-LINK]
* [Usamos C# 10][CSHARP10-LINK]

## TODO
- [ ] Criar descritor de camadas (Layers)
      - Deve ter anotações para objetos de camada e assembly de camadas
- [ ] Criar identificadores para AppService e AppUseCase
      - Ambos devem ser anotados com a camada de aplicação/usecase
      - Anotar os componentes da camada de Domain Driven Design com
        o tipo adequado
- [ ] AppService e AppUseCase devem ter um método que permita executar
      manipuladores de eventos para uma lista de eventos e retornar um
      resumo.
      - Quando uma exceção ocorre nos manipuladores, essa exceção é levantada
        automaticamente e o processo para
      - Quando ocorre bem, o resumo quantifica os eventos executados por
        quais manipuladores, bem como os eventos que não tiveram manipuladores
        para tratar

[NETSDK6-LINK]: https://dotnet.microsoft.com/en-us/download/dotnet/6.0
[NET6-LINK]: https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-6
[CSHARP10-LINK]: https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10
