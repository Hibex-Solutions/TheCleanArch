# Como contribuir com TheCleanArch

Requisitos:

- .NET SDK 8.0 e 10.0

## Aprenda a desenvolva localmente primeiro

Após clonar o repositório, confira se tudo está ok:
```sh
dotnet tool restore
dotnet husky install
dotnet husky run
dotnet docfx ./docs/docfx.json
```

Qualquer falha nessa etapa indica ou um requisito não presente, ou
talvez você tenha até encontrado um bug.

## Encontrou um bug?

* **Não abra um problema no GitHub se o bug for uma vulnerabilidade de segurança no .NET**, em vez disso, entre em contato com a [própria equipe do .NET](https://github.com/dotnet/).

* **Certifique-se de que o bug ainda não foi relatado** pesquisando no GitHub em [Issues](https://github.com/Hibex-Solutions/TheCleanArch/issues).

* Se você não conseguir encontrar uma [issue](https://github.com/Hibex-Solutions/TheCleanArch/issues) em aberto que resolva o problema, [crie uma você mesmo](https://github.com/Hibex-Solutions/TheCleanArch/issues/new). Certifique-se de incluir um **título e uma descrição clara** , o máximo de informações relevantes possível e um **exemplo de código** ou um **caso de teste executável** demonstrando o comportamento esperado que não está ocorrendo.

## Você escreveu um patch que corrige um bug?

* Abra uma nova solicitação pull do GitHub com o patch.

* Certifique-se de que a descrição do PR descreve claramente o problema e a solução. Inclua o número da emissão relevante, se aplicável.

## Você corrigiu espaços em branco, formatou código ou fez um patch puramente cosmético?

Mudanças que são de natureza cosmética e que não acrescentam nada substancial à estabilidade, funcionalidade ou testabilidade a TheCleanArch geralmente não serão aceitas.

## Você pretende adicionar um novo recurso ou alterar um existente?

* Sugira sua mudança na [lista de discussão CleanArch](https://github.com/Hibex-Solutions/TheCleanArch/discussions/categories/ideias) e comece a escrever o código.

* Não abra uma [issue](https://github.com/Hibex-Solutions/TheCleanArch/issues) no GitHub até obter feedback positivo sobre a mudança. As issues do GitHub destinam-se principalmente a relatórios e correções de bugs.

## Você tem dúvidas sobre o código-fonte?

* Faça qualquer pergunta sobre como usar CleanArch na [lista de discussões](https://github.com/Hibex-Solutions/TheCleanArch/discussions/categories/q-a).

TheCleanArch é um esforço voluntário. Nós encorajamos você a contribuir e se juntar a equipe.

Obrigado! :heart: :heart: :heart:

Time CleanArch