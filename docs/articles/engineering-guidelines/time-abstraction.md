# Abstração de tempo

À partir do [.NET 8][NET8] [a abstração de tempo][NET8-TIMEABSTRACTION] foi incorporada ao framework, não havendo mais necessidade de usar abstrações próprias.

As bibliotecas _The Clean Arch_ são construídas para funcionar já à partir dessa versão. Dessa forma você deve sempre utilizar as abstrações de tempo conforme [documentação oficial do framework][NET8-TIMEABSTRACTION] ao invés de usar as implementações (Ex: DateTime) diretamente
em seus códigos.

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

[NET8]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8
[NET8-TIMEABSTRACTION]: https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-8/runtime#time-abstraction