 # Delivery Racer

## Introdução

**Delivery Racer** é o primeiro protótipo de jogo que desenvolvi utilizando Unity com base no curso Complete C# Unity Game Developer 2D por  GameDev.tv Team, Rick Davidson e Gary Pettie. O objetivo deste projeto foi criar um estudo de jogo, onde o jogador assume o controle de um entregador que deve coletar e entregar pacotes ao redor de uma cidade, evitando obstáculos e utilizando power-ups para melhorar seu desempenho.

## Aprendizado e Lições

Desenvolver o **Delivery Racer** proporcionou uma rica experiência de aprendizado, especialmente em relação ao desenvolvimento de jogos com Unity. Aqui estão as principais lições aprendidas durante o processo:

### Design do Jogo

#### 1. **Uso de Animações e Feedback Visual**
   - Compreendi a importância de utilizar feedback visual para indicar ao jogador as mudanças de estado no jogo. Alterações visuais, como a mudança de cor do carro ao coletar um pacote, tornam o jogo mais intuitivo.

#### 2. **Gerenciamento de Velocidade e Dificuldade**
   - Aprendi a manipular a dificuldade do jogo através de ajustes na velocidade do carro, usando diferentes taxas de velocidade. Isso permitiu criar uma experiência de jogo adaptativa, com desafios que se ajustam às ações do jogador.

#### 3. **Criação e Controle de Spawn Points**
   - A experiência de criar e gerenciar spawn points para pacotes e clientes foi crucial para entender como gerar conteúdo de forma procedural. Isso manteve o jogo interessante ao longo do tempo.

### Características Técnicas

### 1. **Estruturação de Scripts e Modularidade**
   - Aprendi a importância de estruturar os scripts de maneira modular. Cada classe, como `Customer`, `Package`, e `Driver`, tem responsabilidades bem definidas, facilitando a manutenção e expansão do código.
   - **Exemplo**: O script `DeliveryActions` gerencia as ações de coleta e entrega de pacotes, mantendo o código organizado e separado das outras funcionalidades do jogo.

### 2. **Gestão de Eventos e Interações no Unity**
   - Utilizamos `UnityEvent` para gerenciar interações entre objetos, como a coleta e entrega de pacotes. Isso nos ajudou a entender como os eventos podem ser usados para criar um fluxo de jogo dinâmico e reativo.
   - **Exemplo**: Os eventos `PackageCollected` e `PackageDelivered` são usados para disparar mudanças no estado do jogo, como a alteração da cor do carro ou a atualização do score.

### 3. **Manutenção e Manipulação de Estados**
   - Implementamos sistemas para gerenciar o estado do jogador e dos pacotes, o que incluiu o controle da velocidade de movimento com base em diferentes condições (colisões, power-ups) e o rastreamento do status de entrega. Aprendemos a importância de manter o código limpo e modular para facilitar ajustes e manutenção.
   - **Exemplo**: No script `Driver`, a velocidade do carro é ajustada com base em colisões e power-ups, aumentando a complexidade e desafio do jogo.

### 4. **Uso de Sprites e Animações**
   - A atribuição dinâmica de sprites a objetos como pacotes e clientes nos ensinou a manipular gráficos 2D no Unity, além de reforçar a importância de recursos visuais na comunicação de informações ao jogador.
   - **Exemplo**: O método `SetColor` no script `DeliveryActions` muda a cor do carro para refletir que ele está carregando um pacote, oferecendo um feedback visual claro para o jogador.

### 5. **Controle de Colisões e Triggers**
   - Implementamos mecanismos de colisão e triggers para detectar quando o jogador coleta um pacote ou atinge um ponto de boost de velocidade. Isso nos ajudou a compreender melhor o sistema de física 2D do Unity.
   - **Exemplo**: Colisões são detectadas para ajustes na velocidade, e triggers são usados para ativar power-ups ou ações específicas, como a coleta de pacotes.

### 6. **Gerenciamento de Recursos e Prefabs**
   - A criação e uso de prefabs para pacotes e clientes foi fundamental para o desenvolvimento eficiente do jogo, permitindo a reutilização de objetos e facilitando a adição de novos elementos ao jogo.
   - **Exemplo**: O script `GameControl` é responsável por criar pacotes e clientes de forma aleatória nos pontos de spawn, garantindo uma jogabilidade variada e dinâmica.

## Conclusão

Desenvolver o **Delivery Racer** foi uma experiência enriquecedora que me permitiu adquirir uma compreensão mais profunda de diversos aspectos do desenvolvimento de jogos com Unity. A modularidade, o gerenciamento de eventos, o feedback visual, e a criação procedural são apenas algumas das lições aprendidas que serão aplicadas em projetos futuros.

---

Qualquer sugestão ou feedback é bem-vindo. Divirta-se jogando **Delivery Racer**!

## Como Jogar

1. **Movimentação**: Use controle padrão XInput para mover o veículo: Gatilhos para acelerar e ré; direcionais para mover para a lateral; e botão X para frear.
2. **Coleta de Pacotes**: Aproximar-se de um pacote para coletá-lo automaticamente.
3. **Entrega**: Leve o pacote até o cliente para completar a entrega.
4. **Efeitos de Velocidade**: Cuidado com os obstáculos que podem diminuir a velocidade, e aproveite os boosts de velocidade para ganhar tempo!

Divirta-se jogando **Delivery Racer**!

