# Playing with Blazor Fluent UI by using the Edaman and Youtube API
[documentation](https://fluentui-blazor.net/)

[Portuguese](https://github.com/fauxtix/EdamanApiWithFluentUI/blob/master/README_PORTUGUESE.MD)

## Educational Purpose

## Educational Purpose

This project was developed as a way of learning and exploring the capabilities of Blazor Fluent UI. 
The main objective is to get to know and experiment with the various components and standards of Blazor Fluent UI. 
Additionally, the YouTube API was incorporated to broaden the scope of exploration, allowing for experimentation with integrating multimedia features into the application.
The Edaman and YouTube APIs were used to obtain recipe data and multimedia content, respectively, to test the frontend and explore their capabilities.



### Learning Objectives

- Gain familiarity with Blazor Fluent UI components and their usage.
- Understand how to integrate external APIs into Blazor applications.
- Practice building responsive and user-friendly web interfaces.
- Explore data visualization and presentation techniques.

## Work in Progress

Please note that this project is currently a work in progress. While it provides basic functionality for recipe search and access to the Edaman and Youtube APIs, it is expected to evolve over time.

### Future Enhancements

- **Additional Components:** The project may incorporate new components and features to enhance usability and functionality.
- **Improved User Experience:** Efforts will be made to enhance the user interface and overall user experience.
- **Bug Fixes and Optimization:** Any reported bugs will be addressed, and code optimization will be performed for better performance.

  ---
## Overview

**BlazorFluentUI_FL** is a web application that leverages multiple APIs to provide a comprehensive cooking and multimedia resources.

1. **Edaman API**: This application utilizes the Edaman API for _recipe search_ functionality and access to a comprehensive _food database_. It allows users to search, browse, and save their favorite recipes.

2. **YouTube API**: The application also integrates the YouTube API for browsing any videos on YouTube. Additionally, it stores video content in a SQLite database for easy access.

Built with Blazor Fluent UI, the application offers a user-friendly interface for an enhanced culinary and multimedia experience.


## Features

- **Recipe Search:** Users can search for recipes based on keywords, ingredients, or dietary preferences.
- **Food Database:** Access to a vast database of ingredients, nutritional information, and recipes.
- **User-friendly Interface:** Intuitive design and navigation for a seamless user experience.
- **Responsive Design:** The application is optimized for various screen sizes and devices.
- **Fast Responses:** Users can select recipes from prior searches, thus avoiding trips to the Edaman API, allowing offline searches for quick access.
- **YouTube Video Search:** Users can browse and watch any videos on YouTube.
- **Video Database Storage:** Video URLs can be stored in a SQLite database, allowing users to keep track of videos that have caught their attention, are marked as favorites, or found useful.

## Screenshots

**Recipes**
***
![fluentUI_Recipes](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e0ded43c-54f4-46a2-b8f9-6ed95e01ebee)
![fluentUI_Recipes_Output](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/00752e20-5350-488d-af77-80f839b6feaa)
![fluentUI_Recipes_Favories](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/89f0f8cf-38e1-4bdc-b154-c797e7fdd460)
![fluentUI_Recipes_ViewInSite](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/6fd77bca-6e84-42cb-a6b5-209a9362fc10)
![fluentUI_Recipes_CuisineType](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/4cb984fd-a460-4635-8dae-90bf377b55da)

**Food Database**
***
![fluentUI_FoodDatabase](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/0a2f414e-df2f-41d8-ac03-7fa91bb8a581)

**Youtube**
***
![FluentUI_Youtube](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/e2f98621-f74f-492e-91d3-fea61581ba70)
![FluentUI_Youtube_Edit](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/ac82d00a-bf7c-47b7-b4e9-b47527b9326d)
![FluentUI_Youtube_Player](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/0a96a4b0-535b-4df3-a65a-3d4e56335e3d)

**Settings (App themes)**
***
![fluentUI_Settings](https://github.com/fauxtix/BlazorFluentUI_FL/assets/49880538/31ce2c8c-d401-4a2b-88f2-7cc2cca522d9)

***
## Installation

To install the Edaman API with Fluent UI locally, follow these steps:

1. **Clone Repository:**
   git clone https://github.com/fauxtix/BlazorFluentUI_FL

2. **Navigate to Directory:**
   cd EdamanFluentApi

3. **Install Dependencies:**
   dotnet restore

4. **Update appsettings.json:**
   Include your Edaman APP_ID and API_KEY keys
   Include your Youtube keys (YouTubeApiKey, YouTubeApplicationName, ClientId and SecretClientId)
   
6. **Run Application:**
   dotnet run

7. **Access Application:**
Open a web browser and go to `http://localhost:<port>`.

## Usage

1. **Search for Recipes:**
   Enter keywords, ingredients, or dietary preferences into the search bar and press enter to see relevant recipes. User choices for saving favorite recipe searches are stored in JSON files for easy access and retrieval.

2. **View Recipe Details:**
   Click on the 'Preparation' button in the recipe card, and navigate to the 'source' site, to view detailed information including ingredients, instructions, and nutritional facts.

3. **Explore Food Database:**
   Browse through the food database to discover new ingredients, recipes, and nutritional information.

4. **Explore Video Database:**
   Browse through the database to discover a wide range of videos covering various topics of interest. Videos from YouTube can be accessed and their information stored in a SQLite database for future reference.

## Technologies Used

- Blazor Fluent UI
- .NET Core 8

## Contributors

- Fausto Luís (fauxtix.luix@hotmail.com)
- Filipa Luís (filipaluis@gmail.com)
- Margarida Luís (margaridaluis@gmail.com


## Acknowledgments

Special thanks to the contributors and the community for their support and feedback.

### Contributions

Contributions are welcome! If you have suggestions for new features or improvements, feel free to submit a pull request or open an issue on GitHub.

### Disclaimer

This project is a work in progress and may undergo changes and updates without prior notice. It is being developed for educational purposes and may include experimental features and components.
It does not serve any commercial or production purposes.

## License

This project is licensed under the MIT License - see the [MIT-LICENSE.TXT](https://github.com/fauxtix/EdamanApiWithFluentUI/blob/master/EdamanFluentApi/MIT-LICENSE.txt) file for details.
