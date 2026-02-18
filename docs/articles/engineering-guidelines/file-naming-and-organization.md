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

Dentro dessas podemos acomodar todos os nossos componentes de software.

# Camada de negócio

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

# Camada de adaptadores

Já a camada de adaptadores pode ser mais extensa, porém normalmente existem
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

# Juntando tudo

Agora veja o exemplo completo considerando que optamos por usar a camada
_Enterprise_, e já ordenado hieraquicamente os arquivos:

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

E agora a relação entre estrutura de diretórios hieráquica e os namespaces _C#_:

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

Agora veja a disposição com os arquivos de projetos alocados em seus respectivos
diretórios (obviamente omitimos alguns para tornar a lista mais prática):

```sh
src/
├─ Business/
│  ├─ Entities/
│  │  └─ Business.Entities.csproj
│  └─ UseCases/
│     └─ Business.UseCases.csproj
└─ InterfaceAdapters/
   ├─ Data/
   │  ├─ ...
   │  └─ RedisCache/
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

Caso, na camada de negócios você tenha apenas o projeto _Use Cases_ e não use
_Enterprise_, você pode omitir o subdiretório:

```sh
src/
├─ Business/
│  └─ Business.UseCases.csproj
└─ InterfaceAdapters/
   ├─ Data/
   │  └─ ...
   ├─ Gateways/
   │  └─ ...
   ├─ UI/
   │  └─ ...
   └─ Workers/
      └─ ...
```

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