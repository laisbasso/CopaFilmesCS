# Campeonato de Filmes :trophy:

Cansado de gastar horas escolhendo um filme e acabar com o balde de pipoca antes mesmo de dar play?

O Campeonato de Filmes nasceu para fazer o match perfeito entre você e o mundo cinematográfico.

Pegue seus 8 tickets e vamos te mostrar quais títulos mais conquistaram o coração do público!

## Screenshots

![Página do campeonato](https://i.imgur.com/JsjzLWo.png "Campeonato")

![Página do resultado](https://i.imgur.com/Nem6gdv.png "Resultado")

## Como funciona?

Na página inicial é apresentada a proposta do Campeonato de Filmes, que tem como objetivo a otimização no processo de escolha de um filme, baseada nas preferências do usuário e na avaliação geral do público.

O usuário é convidado a escolher os 8 títulos que mais lhe interessam, dentre uma lista de 16 filmes recebidas pela API externa. Esses filmes são expostos na página por meio do método `GET`.

O código de barras apresentado em cada ticket é gerado por uma fonte a partir da id do filme, então cada código é único! Legal, né? :)

Um contador regressivo acompanha a rolagem da tela e indica ao usuário quantos filmes ele ainda pode escolher. Também é possível desmarcar um filme selecionado.

Ao atingir a meta de 8 filmes escolhidos, um botão substitui o contador, que ao ser clicado faz o envio dos filmes escolhidos para a nossa API por meio do método `POST`.

Caso tente selecionar um nono filme, um sweet alert informa que já foram escolhidos filmes suficientes e então ele é direcionado à página do resultado.

A página seguinte exibe o resultado dos dois filmes mais bem avaliados de acordo com sua seleção anterior. Também está disponível um botão para fazer uma nova consulta.

## Documentação Front-End

Gerada por meio do [Compodoc](https://laisbasso.github.io/CopaFilmesCS/).

## Documentação Back-End

O Campeonato de Filmes foi construído utilizando .NET Core 3.1.402 e Angular 10.1.5.

## Filme Model

| Atributo | Tipo |
|----------|------|
| Id | string |
| Titulo | string |
| Ano | int |
| Nota | double |

## Filme Service

* `GetAllFilmes()` - Recebe e exibe todos os 16 filmes recebidos da API externa.

* `PostFilmesSelecionados(List<FilmeModel> ListaFilmes)` - Recebe os 8 filmes escolhidos e gera o resultado de acordo com a regra de negócio. Chama os seguintes métodos:

  * `GerarOrdemAlfabetica(List<FilmeModel> ListaFilmes)` - Recebe os filmes escolhidos e os devolve organizados alfabeticamente.

  * `FaseEliminatoria(List<FilmeModel> ListaFilmes)` - Compara a melhor nota entre o primeiro e último filme, segundo e penúltimo filme, e assim sucessivamente. Se os filmes possuírem a mesma nota, o vencedor é o primeiro em ordem alfabética. Os vencedores são retornados em uma nova lista, que devolve metade da quantidade de filmes recebidos. O método é chamado duas vezes para poder retornar apenas os finalistas.

  * `UltimoCombate(List<FilmeModel> ListaFilmes)` - Este método atribui o primeiro e segundo lugar para os filmes finalistas.

## Filme Controller

### Requisições

| Métodos | Endpoints | Descrição |
|----------|--------------|----------|
| ```GET``` | /filme/v1 | Exibe todos os filmes recebidos da API externa
| ```POST``` | /filme/v1 | Envia os oito filmes escolhidos para a nossa API e retorna os dois filmes finalistas

## Dados em JSON :ticket:

### Recebendo 16 filmes

`[GET] /filme/v1`

```json
[
    {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
    },
    {
        "id": "tt4881806",
        "titulo": "Jurassic World: Reino Ameaçado",
        "ano": 2018,
        "nota": 6.7
    }
]
```
### Enviando 8 filmes escolhidos

`[POST] /filme/v1`

```json
[
    {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
    },
    {
        "id": "tt4881806",
        "titulo": "Jurassic World: Reino Ameaçado",
        "ano": 2018,
        "nota": 6.7
    }
]
```

### Retornando 2 filmes finalistas

`[POST] /filme/v1`

```json
[
    {
        "id": "tt4154756",
        "titulo": "Vingadores: Guerra Infinita",
        "ano": 2018,
        "nota": 8.8
    },
    {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
    }
]
```

## Segunda versão :fast_forward:

* Indicação visual dos filmes que já foram escolhidos
* Implementação de filtro por gênero cinematográfico
* Integração com plataforma de streaming
    * Login social
    * Lista inicial personalizada de acordo com o histórico do usuário
    * Lista de favoritos
    * Exibição de player dos filmes finalistas
