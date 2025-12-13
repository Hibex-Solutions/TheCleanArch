# Simplificando as coisas

Por sorte, tudo que você acabou de fazer dos passos 1 ao 4, você não precisá repetir
no seu dia a dia. Sabemos que esses pequenos detalhes são coisas que podemos esquecer no
dia a dia se precisarmos repetir muitas vezes, porém é muito importante entendê-los
e saber porque existem. Por isso fizemos questão de mostrar como fazer tudo manualmente.

Mas agora que você já entendeu como criar um diretório de solução nos padrões
_The Clean Arch_ (se for o caso, volte, releia e repita cada passo), você já pode
utilizar os _templates_ para gerar suas soluções com mais praticidade.

1. Instale os templates.
```sh
dotnet new install TheCleanArch.Templates
```

2. Crie uma solução básica como a que acabamos de criar manualmente.
```sh
dotnet new tca-solution -n Age -o age-project --UseDomainDrivenDesign --EnableOmnisharpExtensions
```

Pronto! Assim é muito mais simples. E acabamos com a mesma estrutura de solução.

> [!TIP]
> Que tal de agora em diante você criar suas soluções .NET dessa forma?

Saiba mais sobre os [_templates The Clean Arch_](https://github.com/Hibex-Solutions/TheCleanArch.Templates).