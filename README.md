![Palavra 'Tamagotchi' em caracteres](./src/Image/readme-capa.png#vitrinedev)
--------------------

Este projeto é uma aplicação em console que simula o brinquedo Tamagotchi (bichinho virtual), no qual os mascotes são pokémons pegos na API [PokeAPI](https://pokeapi.co/api/v2/pokemon/).  
<br>
O projeto faz parte da iniciativa **7 Days of Code**, disponibilizado pela plataforma de ensino Alura. Onde a cada dia, por 7 dias, um desafio é dado e depois dos desafios concluídos terá um projeto pronto.  
<br>
| :placard: Vitrine.Dev |     |
| -------------  | --- |
| :sparkles: Nome        | **Tamagotchi Pokémon**
| :label: Tecnologias | C# .NET 6 AutoMapper
| :fire: Desafio     | https://7daysofcode.io/matricula/csharp


## Desenvolvimento do projeto

1º Escrevi o método que faz a chamada para a [PokeAPI](https://pokeapi.co/api/v2/pokemon/), para obter as informações dos pokémons.
  - Para não ser sempre os mesmos pokémons, o número do `id` usado para fazer a request na API é pego aleatoriamente.  

2º Criei a classe `Pokemon`, e demais classes necessárias, para representar os mascotes.
  - Parsear o JSON obtido da API em uma instancia da classe para exibir somente as características desejadas e de maneira organizada.
  - Os pokémons escolhidos são adicionados a uma lista.  
  
3º Construi o menu interativo para o usuário poder conhecer os pokémons.
  - Saber quais os mascotes estão para adoção, conhecer as suas características e se desejar, adotar um deles.

4º Refatorei o projeto para ficar de acordo com o padrão *Model-View-Controller* (MVC).  

5º Construi o menu de interação do usuário com o mascote adotado.
  - Adicionei à classe `Pokemon` as propriedades `Alimentar`, `Brincar` e `Dormir`, que são as interações disponibilizadas para o usuário ter com o seu mascote.
  - Um tipo de interação afeta as demais e o `Humor` do mascote é afetado pelo valor das propriedades.

6º Fiz o mapeamento de um objeto para outro da classe `Pokemon` usando o `AutoMapper`.

7º Enquanto construia o projeto fui tratando de possíveis erros que poderiam ter na execução, mas ao terminar o projeto fiz uma última verificação para corrigir pontos do projeto aonde poderiam ocorrer erros e que ainda não tinham sido tratados.


