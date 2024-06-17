# 3. Habilite editores

Se você usa uma IDE rica em recursos como [Microsoft Visual Studio][VISUALSTUDIO] e [JetBrains Rider][RIDER], ou um editor inteligente moderno como [VSCode][VSCODE] ou [Sublime Text][SUBLIMETEXT], ou ainda um editor inteligente mais tradicional baseado em terminal como [Emacs][EMACS] e [Neovim][NEOVIM], não importa! A única regra que estabelecemos é que o [.NET SDK][DOTNET] deve ser o único requisito para desenvolver seu código.

> [!TIP]
> Encare isso como uma recomendação arquitetural _The Clean Arch_!

E é para que o código funcione adequadamente em qualquer um desses seus ambientes de desenvolvimento que sugerimos que todas as soluções tenham os arquivos `global.json`, `nuget.config`, `.editorconfig` e `.config/dotnet-tools.json`. Porque eles controlam de forma padronizada cada aspecto relevante do projeto, e faz com que a experiência de codificação seja como esperada usando quaisquer dessas ferramentas, por serem padrões de mercado. Mas nos falta ainda um arquivo, o `omnisharp.json`.

O arquivo `omnisharp.json` será necessário para que editores mais tradicionais como [Emacs][EMACS] e [Neovim][NEOVIM] possam funcionar adequadamente com o mínimo de configuração. Crie então, na raiz da solução o arquivo `omnisharp.json` com o conteúdo mínimo conforme abaixo:

```json
{
  "FormattingOptions": {
    "EnableEditorConfigSupport": false
  },
  "RoslynExtensionsOptions": {
    "enableAnalyzersSupport": true
  }
}
```

Neste arquivo, estamos habilitando minimamente para o projeto, tanto o suporte a configurações do editor via arquivo `.editorconfig` quanto o suporte a análise do [Roslyn][ROSLYN] para refatorações e ações de código no editor.

> [!NOTE]
> Saiba mais em [Configuration Options na Wiki do projeto no GitHub][OMNISHARP_WIKICONFIG].

Pronto! Agora não importa mais qual o editor ou IDE você use, eles devem funcionar minimamente iguais para os principais recursos necessários a uma boa experiência de desenvolvimento, e nossa recomendação arquitetural prevê isso.

<!-- links -->
[VISUALSTUDIO]: https://www.visualstudio.com
[RIDER]: https://www.jetbrains.com/pt-br/rider
[VSCODE]: https://code.visualstudio.com
[SUBLIMETEXT]: https://www.sublimetext.com
[EMACS]: https://www.gnu.org/software/emacs
[NEOVIM]: https://neovim.io
[DOTNET]: https://dot.net
[OMNISHARP_WIKICONFIG]: https://github.com/OmniSharp/omnisharp-roslyn/wiki/Configuration-Options
[ROSLYN]: https://github.com/dotnet/roslyn