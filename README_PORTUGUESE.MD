# Brincando com Blazor Fluent UI usando as APIs Edaman e YouTube
[Documentação](https://fluentui-blazor.net/)

[Inglês](https://github.com/fauxtix/EdamanApiWithFluentUI/blob/master/README.MD)

## Propósito Educacional

Este projeto foi desenvolvido como uma forma de aprender e explorar as capacidades do Blazor Fluent UI.
O objetivo principal é conhecer e experimentar os vários componentes e padrões do Blazor Fluent UI.
Além disso, a API do YouTube foi incorporada para ampliar o escopo de exploração, permitindo a experimentação com a integração de recursos multimédia na aplicação.
As APIs Edaman e YouTube foram utilizadas para obter dados de receitas e conteúdo multimédia, respectivamente, para testar o frontend e explorar suas capacidades.

### Objetivos de Aprendizagem

- Ganhar familiaridade com os componentes do Blazor Fluent UI e a sua utilização.
- Compreender como integrar APIs externas em aplicações Blazor.
- Praticar a construção de interfaces web responsivas e amigáveis ao utilizador.
- Explorar técnicas de visualização e apresentação de dados.

## Trabalho em Progresso

Por favor, note que este projeto está atualmente em desenvolvimento. Embora forneça funcionalidades básicas para pesquisa de receitas e acesso às API do Edaman e Youtube, espera-se que evolua ao longo do tempo.

### Melhorias Futuras

- **Componentes Adicionais:** O projeto pode incorporar novos componentes e recursos para melhorar a usabilidade e funcionalidade.
- **Experiência do Usuário Aprimorada:** Esforços serão feitos para melhorar a interface do usuário e a experiência geral do usuário.
- **Correções de Bugs e Otimização:** Quaisquer bugs relatados serão corrigidos, e otimizações de código serão realizadas para melhor desempenho.

---

## Visão Geral

**BlazorFluentUI_FL** é uma aplicação web que aproveita várias APIs para fornecer recursos abrangentes.

1. **API Edaman:** Esta aplicação utiliza a API Edaman para funcionalidade de _pesquisa de receitas_ e acesso a um _banco de dados de alimentos_ abrangente. Permite que os utilizadores pesquisem, naveguem e salvem as suas receitas favoritas.

2. **API do YouTube:** A aplicação também integra a API do YouTube para navegar em qualquer vídeo no YouTube. Além disso, armazena conteúdo de vídeo num banco de dados SQLite para um fácil acesso.

Construída com Blazor Fluent UI, a aplicação oferece uma interface amigável para uma experiência culinária e multimídia aprimorada.

## Recursos

- **Pesquisa de Receitas:** Os utilizadores podem pesquisar receitas com base em palavras-chave, ingredientes ou preferências alimentares. As escolhas do utilizador para salvar pesquisas de receitas favoritas, são armazenadas em arquivos JSON para fácil acesso e recuperação.
- **Base de Dados de Alimentos:** Acesso a uma vasta base de dados de ingredientes, informações nutricionais e receitas.
- **Interface Amigável:** Design intuitivo e navegação para uma experiência de fácil utilização.
- **Design Responsivo:** A aplicação é otimizada para vários tamanhos de ecrans e dispositivos.
- **Respostas Rápidas:** Os utilizadores podem selecionar receitas de pesquisas anteriores, evitando viagens à API do Edaman, permitindo pesquisas offline para acesso rápido.
- **Pesquisa de Vídeo do YouTube:** Os utilizadores podem navegar e assistir a qualquer vídeo no YouTube, através de 'Player' incluído.
- **Armazenamento de Banco de Dados de Vídeo:** Os URLs dos vídeo são armazenados numa base de dados SQLite, permitindo que os utilizadores acompanhem vídeos que chamaram sua atenção, foram marcados como favoritos ou que foram classificados como úteis.

## Capturas de Tela

![Pesquisa de Receitas](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/e5f0c4f2-158f-4a08-81ed-c8c342fd2469)
![Resultado da Pesquisa de Receitas](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/f1d5bc1a-1866-4413-9d0a-a763cdb9b80c)

**Pesquisa de Receitas**
***
![Pesquisa da Base de Dados de Alimentos](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/de5d9040-4905-496e-930c-d8d990eb11fe)

**Pesquisa da Base de Dados de Alimentos**
***
## Instalação

Para instalar a API Edaman com Fluent UI localmente, siga estas etapas:

1. **Clonar Repositório:**
   git clone https://github.com/fauxtix/BlazorFluentUI_FL

2. **Navegar para o Diretório:**
   cd EdamanFluentApi

3. **Instalar Dependências:**
   dotnet restore

4. **Atualizar appsettings.json:**
   Inclua as suas chaves APP_ID e API_KEY do Edaman
   Inclua as suas chaves do Youtube (YouTubeApiKey, YouTubeApplicationName, ClientId e SecretClientId)
   
6. **Executar Aplicação:**
   dotnet run

7. **Aceder à aplicação:**
Abra um navegador da web e aceda a `http://localhost:<porta>`.

## Utilização

1. **Pesquisar Receitas:**
   Insira palavras-chave, ingredientes ou preferências alimentares na barra de pesquisa e pressione [Enter] para ver receitas relevantes. As escolhas do utilizador para salvar pesquisas de receitas favoritas, são armazenadas em arquivos JSON para fácil acesso e recuperação.

2. **Visualizar Detalhes da Receita:**
   Clique no botão 'Preparation' no 'cartão da receita' e navegue até ao site de origem para visualizar informações detalhadas, incluindo ingredientes, instruções e fatos nutricionais.

3. **Explorar Base de Dados de Alimentos:**
   Navegue pela base de dados de alimentos para descobrir novos ingredientes, receitas e informações nutricionais.

4. **Explorar Base de Dados de Vídeo:**
   Navegue pela base de dados para descobrir uma ampla variedade de vídeos, cobrindo vários tópicos de interesse. Vídeos do YouTube podem ser acedidos e suas informações armazenadas

## Tecnologias Utilizadas

- Blazor Fluent UI
- .NET Core 8

## Contribuidores

- Fausto Luís (fauxtix.luix@hotmail.com)
- Filipa Luís (filipaluis@gmail.com)
- Margarida Luís (margaridaluis@gmail.com)

## Agradecimentos

Um agradecimento especial aos contribuidores e à comunidade pelo seu apoio e feedback.

### Contribuições

As contribuições são bem-vindas! Se tiver sugestões para novas funcionalidades ou melhorias, sinta-se à vontade para enviar um 'pull request' ou abrir uma 'issue' no GitHub.

### Aviso Legal

Este projeto está em desenvolvimento e pode sofrer alterações e atualizações sem aviso prévio. Está sendo desenvolvido apenas para fins educacionais e pode incluir recursos e componentes experimentais. Não serve a nenhum propósito comercial ou de produção.

## Licença

Este projeto está licenciado sob a Licença MIT - consulte o arquivo [MIT-LICENSE.TXT](https://github.com/fauxtix/EdamanApiWithFluentUI/blob/master/BlazorFluentUI_FL/MIT-LICENSE.txt) para mais detalhes.
