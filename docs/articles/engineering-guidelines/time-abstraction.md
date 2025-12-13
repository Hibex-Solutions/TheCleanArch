# Abstração de tempo

À partir do [.NET 8][NET8] [a abstração de tempo][NET8-TIMEABSTRACTION] foi incorporada ao framework, não havendo mais necessidade de usar abstrações próprias.

As bibliotecas _The Clean Arch_ são feitas para funcionar à partir do [.NET 6][NET6],
e para não incluir mais uma abstração própria, o componente `TheCleanArch.Core` depende de [Microsoft.Bcl.TimeProvider][BCL-TIMEPROVIDER]. Dessa forma você pode simplesmente utilizar as abstrações de tempo conforme [documentação oficial do framework][NET8-TIMEABSTRACTION] mesmo que não esteja utilizando [.NET 10][NET10] ainda.

> [!WARNING]
> Não use mais `DateTime.UtcNow()` diretamente!
```cs
using System;

class MyClass
{
    void MyMethod()
    {
        DateTime.NowUtc();
    }
}
```

> [!NOTE]
> Use a abstração `TimeProvider.GetUtcNow()`
```cs
using System;

class Mclass MyClass
{
    public MyClass(TimeProvider timeProvider)
    {
        //...
    }

    void MyMethod()
    {
        timeProvider.NowUtc();
    }
}
```

[NET6]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6
[NET8]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8
[NET10]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-10/overview
[NET8-TIMEABSTRACTION]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8/runtime#time-abstraction
[BCL-TIMEPROVIDER]: https://www.nuget.org/packages/Microsoft.Bcl.TimeProvider