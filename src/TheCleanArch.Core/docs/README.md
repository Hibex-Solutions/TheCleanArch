![The Clean Arch for .NET](https://raw.githubusercontent.com/Hibex-Solutions/TheCleanArch/main/docs/assets/CleanArchBanner.png)

## TheCleanArch.Core

Utilitários base para The Clean Arch.

### Guard Clause

> Saiba mais em https://deviq.com/design-patterns/guard-clause

Use para garantir a consistência dos parâmetros em seus métodos.

```c#
using TheCleanArch.Core.Patterns.GuardClauses;

class MyClass
{
    readonly MyService _myService;

    MyClass(MyService myService, int param1, string param2)
    {
        _myService = Guard.NotNullArgument(myService, nameof(myService));

        _ = Guard.NotNullArgument(param1, nameof(param1));
        _ = Guard.NotEmptyArgument(param1, nameof(param2));

        // ...
    }
}
```