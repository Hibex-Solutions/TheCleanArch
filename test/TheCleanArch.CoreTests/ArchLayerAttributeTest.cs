// Copyright (c) The Clean Arch Project. All rights reserved.
// This file is a part of TheCleanArch.
// Licensed under the Apache version 2.0: LICENSE file.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;

using TheCleanArch.Core;

namespace TheCleanArch.CoreTests;

[Trait("target", nameof(ArchLayerAttribute))]
public class ArchLayerTest
{
    [Fact(DisplayName = "ArchLayer pode ser atribuído a um Assembly")]
    public void ArchLayerCanBeAssignedToAnAssembly()
    {
        var code = @"
            using TheCleanArch.Core;

            [assembly: ArchLayerAttribute]
        ";

        var compileResult = CompileCSharpCode(code);

        Assert.NotNull(compileResult);
        Assert.True(compileResult.Success);
    }

    [Theory(DisplayName = "ArchLayer não pode ser atribuído a nada que não seja um Assembly")]
    [MemberData(nameof(CodesWithInvalidUseOfArchLayerAttribute))]
    public void ArchLayerCannotBeAssignedToAnythingOtherThanAnAssembly(string code)
    {
        var compileResult = CompileCSharpCode(code);

        Assert.NotNull(compileResult);
        Assert.False(compileResult.Success);

        // https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/compiler-messages/cs0592
        Assert.Contains(compileResult.Diagnostics, d => string.Equals(d.Id, "cs0592", StringComparison.OrdinalIgnoreCase));
    }

    public static TheoryData<string> CodesWithInvalidUseOfArchLayerAttribute = new()
        {
            // Não pode ser atribuído a parâmetros genéricos
            @"
            using TheCleanArch.Core;

            public class MyGenericClass<[ArchLayerAttribute] TGenericParameter> { }",

            // Não pode ser atribuído a valores de retorno
            @"
            using TheCleanArch.Core;

            public class MyClass
            {
                [return: ArchLayerAttribute]
                int MyMethod() {}
            }",

            // Não pode ser atribuído a delegados
            @"
            using TheCleanArch.Core;

            [ArchLayerAttribute]
            public delegate void MyDelegate();",

            // Não pode ser atribuído a parâmetros
            @"
            using TheCleanArch.Core;

            public class MyClass
            {
                void MyMethod([ArchLayerAttribute]object myParameter) {}
            }",

            // Não pode ser atribuído a eventos
            @"
            using System;
            using TheCleanArch.Core;

            public class MyClass
            {
                [ArchLayerAttribute]
                event EventHandler<object> MyEvent;
            }",

            // Não pode ser atribuído a construtores
            @"
            using TheCleanArch.Core;

            public class MyClass
            {
                [ArchLayerAttribute]
                MyClass(){}
            }",

            // Não pode ser atribuído a módulos
            @"
            using TheCleanArch.Core;

            [module: ArchLayerAttribute]
            namespace MyModule;",
            
            // Não pode ser atribuído a enumeradores
            @"
            using TheCleanArch.Core;

            [ArchLayerAttribute]
            public enum MyEnum {}",

            // Não pode ser atribuído a estruturas
            @"
            using TheCleanArch.Core;

            [ArchLayerAttribute]
            public struct {}",

            // Não pode ser atribuído a interfaces
            @"
            using TheCleanArch.Core;

            [ArchLayerAttribute]
            public interface IMyInterface {}",

            // Não pode ser atribuído a métodos
            @"
            using TheCleanArch.Core;

            public class MyClass {
                [ArchLayerAttribute]
                public void MyMethod() {}
            }",

            // Não pode ser atribuído a propriedades
            @"
            using TheCleanArch.Core;

            public class MyClass {
                [ArchLayerAttribute]
                public string myProperty { get; set; }
            }",

            // Não pode ser atribuído a campos
            @"
            using TheCleanArch.Core;

            public class MyClass {
                [ArchLayerAttribute]
                public string myField;
            }",

            // Não pode ser atribuído a classes
            @"
            using TheCleanArch.Core;
            
            [ArchLayerAttribute]
            public class MyClass { }"
        };

    private static EmitResult CompileCSharpCode(string code)
    {
        var clrPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
        var theCleanArchCoreAssembly = typeof(Core.Patterns.GuardClauses.Guard).Assembly;

        var tree = CSharpSyntaxTree.ParseText(code);
        var options = new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary);
        var compilation = CSharpCompilation.Create(null)
            .WithOptions(options)
            .AddReferences(MetadataReference.CreateFromFile(theCleanArchCoreAssembly.Location))
            .AddReferences(Ref("mscorlib"))
            .AddReferences(Ref("System.Private.CoreLib"))
            .AddReferences(Ref("System"))
            .AddReferences(Ref("System.Runtime"))
            .AddSyntaxTrees(tree);

        using var ms = new MemoryStream();
        var result = compilation.Emit(ms);

        return result;

        MetadataReference Ref(string s)
        {
            return MetadataReference.CreateFromFile(Path.Combine(clrPath!, $"{s}.dll"));
        };
    }
}