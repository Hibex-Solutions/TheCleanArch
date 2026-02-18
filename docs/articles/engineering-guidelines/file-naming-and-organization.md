# Nomenclatura e organização de arquivos do projeto

Nomeamos nossos arquivos de projetos em conformidade com as ideias centrais
[expostas pela definição de _Clean Architecture_ conforme artigo](BLOG_ARTICLE), e que tem a imagem a seguir como guia.

![](../../images/TheCleanArchitectureBlogImage.jpg)

Temos então 4 camadas principais (no desenho - o próprio autor reforça que a
quantidade de camadas não faz parte da definição apresentada). Sendo duas delas
para regras de negócio (Entities e Use Cases), uma para os vários adaptadores
de interfaces possíveis, e outra para drivers e frameworks que raramente
escreveremos.

Ainda que a definição de _Clean Architecture_ se aplique a uma gama de softwares
onde _Frameworks & Drivers_ se aplique, na nossa definição de **TheCheanArch**
não consideramos essa última camada para fins de aplicabilidade no tipo de
software que consideramos.

Então, se excluirmos essa última camada sobram 3 outras. Essas ainda podem ser
resumidas em 2 categorias:

- Business
- InterfaceAdapters

Dentro dessas podemos acomodar todos os nossos componentes de software, e se
necessário ainda podem ser organizados em subcategorias.

## Camada de negócio

Em **Business** temos (caso esteja olhando para o círculo):

- Entities
- UseCases

Ou se preferir (se estiver olhando para a descrição dos círculos):

- Application
- Enterprise

> [!NOTE]
> A camada _Entities_ (ou _Enterprise_) não é obrigatória. Essa também poderia
> se chamar _Domain_ (é o como muitos chamam) caso você use _DDD_ para
> implementá-la. Mas visto que _DDD_ é uma técnica e não o nome de uma camada
> de fato em _Clean Architecture_, preferimos referenciar as camadas conforme
> _Clean Architecture_ determina. Saiba mais em
> ["Quando usar Domain Driven Design?"](when-to-use-domain-driven-design.md).

Então se tivermos a camada _Enterprise_:

- Business
  - Entities (_aqui ficaria a implementação DDD_)
  - UseCases
- InterfaceAdapters

Já se não usarmos a camada _Enterprise_:

- Business
  - UseCases
- InterfaceAdapters

Nesses casos, temos a categoria **Business**, e dentro só cabem dois componentes:
**Entities** e **UseCases**.

## Camada de adaptadores

Já a camada de adaptadores pode ser mais extensa e por isso usaremos normalmente
quatro subcategorias específicas:

- DataAccess (para acesso a dados - ou só "Data")
- Gateways (para comunicação externa diversa)
- UserInterfaces (para interfaces do usuário - ou só "UI")
- WorkerServices (para serviços de trabalhos em segundo plano - ou só "Workers")

Então temos algo como:

- InterfaceAdapters
  - Data
  - Gateways
  - UI
  - Workers

Vejamos uma lista com exemplos de componentes adaptadores:

- InterfaceAdapters
  - Data
    - CouchDB
    - EFMongoDB
    - EFPostgres
    - KafkaStreaming
    - NativeMongoDB
    - RabbitMQBroker
    - RedisCache
  - Gateways
    - GitHub
    - GoogleMaps
    - Stripe
  - UI
    - CliApp
    - MobileAndroidApp
    - MobileIOSApp
    - WebApi
    - WebApp
  - Workers
    - PaymentProcessorWorkerService
    - StatusUpdateWorkerService

## Juntando tudo e exemplificando melhor

Agora veja o exemplo completo considerando que optamos por usar a camada
_Enterprise_, e já ordenando hieraquicamente os arquivos:

- Business
  - Entities
  - UseCases
- InterfaceAdapters
  - Data
    - CouchDB
    - EFMongoDB
    - EFPostgres
    - KafkaStreaming
    - NativeMongoDB
    - RabbitMQBroker
    - RedisCache
  - Gateways
    - GitHub
    - GoogleMaps
    - Stripe
  - UI
    - CliApp
    - MobileAndroidApp
    - MobileIOSApp
    - WebApi
    - WebApp
  - Workers
    - PaymentProcessorWorkerService
    - StatusUpdateWorkerService

Veja como a estrutura de diretórios combina bem com a visão de namespaces do _C#_:

```sh
src/
├─ Business/
│  ├─ Entities/                          # Business.Entities
│  └─ UseCases/                          # Business.UseCases
└─ InterfaceAdapters/
   ├─ Data/
   │  ├─ CouchDB/                        # InterfaceAdapters.Data.CouchDB
   │  ├─ EFMongoDB/                      # InterfaceAdapters.Data.EFMongoDB
   │  ├─ EFPostgres/                     # InterfaceAdapters.Data.EFPostgres
   │  ├─ KafkaStreaming/                 # InterfaceAdapters.Data.KafkaStreaming
   │  ├─ NativeMongoDB/                  # InterfaceAdapters.Data.NativeMongoDB
   │  ├─ RabbitMQBroker/                 # InterfaceAdapters.Data.RabbitMQBroker
   │  └─ RedisCache/                     # InterfaceAdapters.Data.RedisCache
   ├─ Gateways/
   │  ├─ GitHub/                         # InterfaceAdapters.Gateways.GitHub
   │  ├─ GoogleMaps/                     # InterfaceAdapters.Gateways.GoogleMaps
   │  └─ Stripe/                         # InterfaceAdapters.Gateways.Stripe
   ├─ UI/
   │  ├─ CliApp/                         # InterfaceAdapters.UI.CliApp
   │  ├─ MobileAndroidApp/               # InterfaceAdapters.UI.MobileAndroidApp
   │  ├─ MobileIOSApp/                   # InterfaceAdapters.UI.MobileIOSApp
   │  ├─ WebApi/                         # InterfaceAdapters.UI.WebApi
   │  └─ WebApp/                         # InterfaceAdapters.UI.WebApp
   └─ Workers/
      ├─ PaymentProcessorWorkerService/  # InterfaceAdapters.Workers.PaymentProcessorWorkerService
      └─ StatusUpdateWorkerService/      # InterfaceAdapters.Workers.StatusUpdateWorkerService
```

Os arquivos de projetos (componentes) devem estar dentro do diretório (subdiretório)
de componente:

```sh
src/
├─ Business/                           # Diretório de categoria
│  ├─ Entities/                        # Diretório de componente
│  │  └─ Business.Entities.csproj
│  └─ UseCases/
│     └─ Business.UseCases.csproj
└─ InterfaceAdapters/                  # Diretório de categoria
   ├─ Data/                            # Diretório de subcategoria
   │  ├─ ...
   │  └─ RedisCache/                   # Diretório de componente
   │     └─ InterfaceAdapters.Data.RedisCache.csproj
   ├─ Gateways/
   │  ├─ ...
   │  └─ Stripe/
   │     └─ InterfaceAdapters.Gateways.Stripe.csproj
   ├─ UI/
   │  ├─ ...
   │  └─ WebApp/
   │     └─ InterfaceAdapters.UI.WebApp.csproj
   └─ Workers/
      ├─ ...
      └─ StatusUpdateWorkerService/
         └─ InterfaceAdapters.Workers.StatusUpdateWorkerService.csproj
```

Quando você tem apenas um componente dentro da categoria ou subcategoria, você
pode combinar o diretório do projeto com o diretório de categoria ou subcategoria,
e esse será o diretório do projeto.

No exemplo a seguir, temos apenas um componente `Business.UseCases.csproj` na
categoria `Business`, e ele está no diretório de componente `Business/UseCases`.

```sh
src/
├─ Business/
│  └─ UseCases/
│     └─ Business.UseCases.csproj
└─ InterfaceAdapters/
   └─ ...
```

Você pode combinar o diretório de componente `UseCases` com o diretório da
categoria `Business` e esse será o diretório do componente diretamente:

```sh
src/
├─ Business.UseCases/
│  └─ Business.UseCases.csproj
└─ InterfaceAdapters/
   └─ ...
```

Nesse outro exemplo, agora temos apenas um componente para cada subcategoria
de `InterfaceAdapters`.

```sh
src/
├─ Business/
│  └─ ...
└─ InterfaceAdapters/
   ├─ Data/
   │  └─ RedisCache/
   │     └─ InterfaceAdapters.Data.RedisCache.csproj
   ├─ Gateways/
   │  └─ Stripe/
   │     └─ InterfaceAdapters.Gateways.Stripe.csproj
   ├─ UI/
   │  └─ WebApp/
   │     └─ InterfaceAdapters.UI.WebApp.csproj
   └─ Workers/
      └─ StatusUpdateWorkerService/
         └─ InterfaceAdapters.Workers.StatusUpdateWorkerService.csproj
```

Você também pode combiná-los assim:

```sh
src/
├─ Business/
│  └─ ...
└─ InterfaceAdapters/
   ├─ Data.RedisCache/
   │     └─ InterfaceAdapters.Data.RedisCache.csproj
   ├─ Gateways.Stripe/
   │     └─ InterfaceAdapters.Gateways.Stripe.csproj
   ├─ UI.WebApp/
   │     └─ InterfaceAdapters.UI.WebApp.csproj
   └─ Workers.StatusUpdateWorkerService/
         └─ InterfaceAdapters.Workers.StatusUpdateWorkerService.csproj
```

Imagine que seu projeto tem apenas um componente _Business_, e também apenas um
adaptador de interfaces, como a seguir:

```sh
src/
├─ Business/
│  └─ UseCases/
│     └─ Business.UseCases.csproj
└─ InterfaceAdapters/
   └─ UI/
      └─ CliApp/
         └─ InterfaceAdapters.UI.CliApp.csproj
```

Você pode simplificar tudo assim:

```sh
src/
├─ Business.UseCases/
│  └─ Business.UseCases.csproj
└─ InterfaceAdapters.UI.CliApp/
   └─ InterfaceAdapters.UI.CliApp.csproj
```

> [!IMPORTANT]
> Temos um padrão: Quando há apenas um componente dentro da categoria ou
> subcategoria, devemos combinar os diretórios em um só diretório de componente.


## Conclusão

Com isso alcançamos uma configuração de nomenclatura que reflete não só os
princípios de camadas apresentados em _Clean Architecture_, mas também permite
a convivência entre visualização em sistemas de arquivos e namespaces do nosso
código.

> [!NOTE]
> Talvez você pense que o simples fato de escolher nomes de arquivos e disposição
> de diretórios e subdiretórios que permitam uma boa visualização, considerando
> inclusive ordem alfabética, seja algo exagerado. Mas quando você se ver hora
> trabalhando em uma IDE, e outra em outra IDE, e talvez usando um editor mais
> simples (Como VSCode) sem recursos de visualização disponíveis em IDEs. Então
> você encontrará o valor dessa decisão. Lembre-se que uma de nossas definições
> é ser independentes de IDEs (ou editores).

<!-- links -->

[BLOG_ARTICLE]: https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html