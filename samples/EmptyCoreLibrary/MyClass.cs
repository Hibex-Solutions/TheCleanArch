namespace EmptyCoreLibrary;

/// <summary>
/// Classe de exemplo na biblioteca
/// </summary>
/// <remarks>
/// Sempre documente suas classes. Essa é a documentação de desenvolvimento principal.
/// </remarks>
public class MyClass
{
    private readonly object _instance;

    public MyClass(object instance)
    {
        _instance = Guard.NotNullArgument(instance, nameof(instance));
    }
}