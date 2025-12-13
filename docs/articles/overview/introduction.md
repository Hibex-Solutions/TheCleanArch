# O que é _The Clean Arch_?

O termo _Clean Architecture_ (Arquitetura Limpa) foi cunhado inicialmente por _Robert C. Martin (Uncle Bob)_ por volta de 2008, e está disponível em seu blog com última atualização em 2012 como ["The Clean Architecture"][BLOG_POST]. _Clean Architecture_ envolve uma série de boas práticas para o desenvolvimento de software de forma sustentável. Desde que o termo foi cunhado por _Uncle Bob_, muitas pessoas vem procurando traduzir melhor suas ideias e implementá-las em várias tecnologias, fazendo isso através de templates, bibliotecas, além de inúmeros tutoriais guias espalhados pelo vasto terreno da Web.

Vale ressaltar que _Uncle Bob_ se vale da definição e trabalhos feitos por outras pessoas como _Alistair Cockburn_ e sua [Hexagonal Architecture][HEXAGONAL_PAGE] (também conhecida como _Ports and Adapters_), ou _Jeffrey Palermo_ e a [Onion Architecture][ONION_PAGE]. _Uncle Bob_, concordando com os pontos de vista desses e de outros também ([veja as menções no próprio artigo][BLOG_POST]), acrescenta suas próprias ideias como [Screaming Architecture][SCREAMING_POST], além de resumir bem todas elas juntas nesse [compilado que postou em seu blog][BLOG_POST]. Você vai encontrar mais detalhes ainda sobre o assunto no livro do próprio _Uncle Bob_ entitulado [_"Arquitetura Limpa - O Guia do Artesão para Estrutura e Design de Software"_][BOOK_AMAZON], e lá você encontra o restante das informações que precisa.

O fato é que essas ideias são a base para o que implementamos aqui no projeto _"The Clean Arch"_. Pretendemos ser um ponto de partida seguro, e talvez uma referência para você implementar seus softwares sob esses fundamentos no que diz respeito a arquitetura de software. Inicialmente focado em [.NET][DOTNET], mas pretendemos expandir para outras tecnologias, porque entendemos que o conceito é independente de tecnologia.

Sabemos que existem inúmeras implementações já disponíveis na _Web_. Sabemos também que existem muitas formas de fazer a mesma coisa, e uma não torna a outra incorreta, apenas diferentes. Não podemos deixar de mencionar que  existem muitos equívocos em algumas implementações que estão disponíveis também, mas a grande maioria está de acordo com os princípios. Talvez cometamos alguns equívocos aqui também em nossas definições, mas estamos prontos a voltar atrás e corrigir o que for necessário, logo, esteja à vontade para nos ajudar com isso.

Podemos concordar então que o projeto _"The Clean Arch"_ é apenas mais uma dessas implementações. Talvez o que tenhamos de diferente seja o fato de que queremos disponibilizar essa implementação da seguinte forma:

1) Totalmente _Open Source_
2) Uma documentação como _Guia_
3) Um conjunto _Mínimo de Bibliotecas_ para viabilizar a implementação
4) Um conjunto de _Ferramentas_ para validações

Então resumimos o projeto _"The Clean Arch"_ como um **Guia Open Source com Mínimo de Bibliotecas e Ferramentas** para implementar _"The Clean Architecture"_ conforme _Uncle Bob_ definiu em seu artigo.

Então seja bem vindo(a) a documentação _"The Clean Arch"_, aqui você aprenderá tanto a usar as bibliotecas e as ferramentas do projeto, quanto aprenderá sobre _"Arquitetura Limpa"_. Aprecie o conteúdo sem moderação!

<!-- links -->
[BLOG_POST]: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html
[HEXAGONAL_PAGE]: https://alistair.cockburn.us/hexagonal-architecture/
[ONION_PAGE]: https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/
[SCREAMING_POST]: https://blog.cleancoder.com/uncle-bob/2011/09/30/Screaming-Architecture.html
[BOOK_AMAZON]: https://www.amazon.com.br/Arquitetura-Limpa-Artes%C3%A3o-Estrutura-Software/dp/8550804606
[DOTNET]: https://dot.net
