# Brincando com Blazor Fluent UI usando as APIs Edaman e YouTube
[Documentação](https://fluentui-blazor.net/)

[Inglês](https://github.com/fauxtix/BlazorFluentUI_FL/blob/master//README.md)

## Propósito Educacional

Este projeto foi desenvolvido como uma forma de aprender e explorar as capacidades do Blazor Fluent UI.
O objetivo principal é o de conhecer e experimentar os seus vários componentes e padrões.
Além disso, a API do YouTube foi incorporada para ampliar o escopo de exploração, permitindo a experimentação com a integração de recursos multimédia na aplicação.
As APIs Edaman e YouTube foram utilizadas para obter dados de receitas e conteúdo multimédia, respectivamente, para testar o frontend e explorar as suas capacidades.

### Objetivos de Aprendizagem

- Ganhar familiaridade com os componentes do Blazor Fluent UI e a sua utilização.
- Compreender como integrar APIs externas em aplicações Blazor.
- Praticar a construção de interfaces web responsivas e amigáveis ao utilizador.
- Explorar técnicas de visualização e apresentação de dados.

## Trabalho em Progresso

Por favor, note que este projeto está atualmente em desenvolvimento. Embora forneça funcionalidades básicas para pesquisa de receitas e acesso às API do Edaman e Youtube, espera-se que evolua ao longo do tempo.

### Melhorias Futuras

- **Componentes Adicionais:** O projeto pode incorporar novos componentes e recursos para melhorar a sua utilização e funcionalidade.
- **Correções de Bugs e Otimização:** Quaisquer bugs relatados serão corrigidos, e otimizações de código serão realizadas para melhor desempenho.

---

## Visão Geral

**BlazorFluentUI_FL** é uma aplicação web que aproveita várias APIs para fornecer recursos abrangentes.

1. **API Edaman:** Esta aplicação utiliza a API Edaman para funcionalidade de _pesquisa de receitas_ e acesso a um _banco de dados de alimentos_ abrangente. Permite que os utilizadores pesquisem, naveguem e guardem as suas receitas favoritas.

2. **API do YouTube:** A aplicação também integra a API do YouTube para navegar em qualquer vídeo no YouTube. Além disso, armazena o conteúdo de vídeo numa base de dados SQLite para um fácil acesso.

Construída com Blazor Fluent UI, a aplicação oferece uma interface amigável para uma experiência culinária e multimédia.

## Recursos

- **Pesquisa de Receitas:** Os utilizadores podem pesquisar receitas com base em palavras-chave, ingredientes ou preferências alimentares. As escolhas do utilizador para salvar pesquisas de receitas favoritas, são armazenadas em arquivos JSON para fácil acesso e recuperação.
- **Base de Dados de Alimentos:** Acesso a uma vasta base de dados de ingredientes, informações nutricionais e receitas.
- **Interface Amigável:** Design intuitivo e navegação para uma experiência de fácil utilização.
- **Design Responsivo:** A aplicação é otimizada para vários tamanhos de ecrans e dispositivos.
- **Respostas Rápidas:** Os utilizadores podem selecionar receitas de pesquisas anteriores, evitando viagens à API do Edaman, permitindo pesquisas offline para acesso rápido.
- **Pesquisa de Vídeo do YouTube:** Os utilizadores podem navegar e assistir a qualquer vídeo no YouTube, através de 'Player' incluído.
- **Armazenamento de Banco de Dados de Vídeo:** Os URLs dos vídeo são armazenados numa base de dados SQLite, permitindo que os utilizadores acompanhem vídeos que chamaram sua atenção, foram marcados como favoritos ou que foram classificados como úteis.
- **Configurações:** Configurar o tema da aplicação (claro ou escuro).
- **Gestão de Categorias de Vídeos:** Adicionar, editar, excluir e pesquisar categorias de vídeos.

## Capturas de Ecrãs

**Receitas**
***
![fluentUI_Recipes](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e0ded43c-54f4-46a2-b8f9-6ed95e01ebee)
![fluentUI_Recipes_Output](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/00752e20-5350-488d-af77-80f839b6feaa)
![fluentUI_Recipes_Favories](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/89f0f8cf-38e1-4bdc-b154-c797e7fdd460)

Em cada receita existe uma opção ('_Preparation_') para aceder à preparação da receita (site de origem).

![fluentUI_Recipes_ViewInSite](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/6fd77bca-6e84-42cb-a6b5-209a9362fc10)

Pesquisando receitas por regiões do mundo (neste caso, 'French' - Francesas / 'deserts' - sobremesas)

![fluentUI_Recipes_CuisineType](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/4cb984fd-a460-4635-8dae-90bf377b55da)

**Base de dados de comida**
![fluentUI_FoodDatabase](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/0a2f414e-df2f-41d8-ac03-7fa91bb8a581)

**Youtube**
***
![FluentUI_Youtube](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e2f98621-f74f-492e-91d3-fea61581ba70)

Criando uma nova entrada. Basta incluir o url do vídeo no Youtube e escolher '_Get metadata_'

![FluentUI_Youtube_Search](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/a71164aa-566e-4d1c-a7ed-18773d52385d)

Depois de pesquisar o Api, o ecrã é preenchido com os _metadados_ recebidos, com a opção de gravação na base de dados.

![FluentUI_Youtube_Edit](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/ac82d00a-bf7c-47b7-b4e9-b47527b9326d)

Na grelha de apresentação dos dados, existe uma opção para reprodução de vídeos, que abrirá um _media player_.

![FluentUI_Youtube_Player](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/0a96a4b0-535b-4df3-a65a-3d4e56335e3d)

**Configuração (Temas da aplicação e Gestão de Categorias de Vídeos)**
***
![fluentUI_Settings_Themes](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/bc772a07-bae0-4075-8447-dd50133ad593)
![fluentUI_Settings_CategoriesManager](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e56ce542-383a-4084-8ddb-3d626e05415c)
![fluentUI_Settings_CategoryEdit](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/fe207476-6fa8-4948-8c1c-eefac989ee71)
![fluentUI_Settings_CategoryDelete](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/5a48e8b3-5655-4ac8-b845-bf73ed104649)
![fluentUI_Settings_CategoryDelete_InUse](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e537f17f-f7e7-45e0-80bd-3c44acdd328b)
![fluentUI_Settings_CategoriesSearch](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/db8a80d3-f955-4154-8442-fd49b78dccbe)

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
   Navegue pela base de dados para descobrir uma ampla variedade de vídeos, cobrindo vários tópicos de interesse. Os vídeos do YouTube podem ser acedidos e as suas informações armazenadas

## Tecnologias Utilizadas

- C#
- Entity Framework Core
- HttpClient para aceder a Apis externos
- AutoMapper
- Blazor Server com 'Interactive Rendering'
- Componentes do Blazor Fluent UI
- .NET Core 8

## Contribuições

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
