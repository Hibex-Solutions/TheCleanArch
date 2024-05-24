# TheCleanArch.Core

Utilitários base para The Clean Arch.

## Guard Clause

> Saiba mais em https://deviq.com/design-patterns/guard-clause

Use para garantir a consistência dos parâmetros em seus métodos.

```c#
using TheCleanArch.Core.Patterns.GuardClauses;

void MyMethod(object param1, string param2)
{
    _ = Guard.NotNullArgument(param1, nameof(param1));
    _ = Guard.NotEmptyArgument(param1, nameof(param2));

    // ...
}
```