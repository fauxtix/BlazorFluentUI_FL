# Blazor Fluent UI with the Edaman API
[documentation](https://fluentui-blazor.net/)

[Portuguese](https://github.com/fauxtix/EdamanApiWithFluentUI/blob/master/README_PORTUGUESE.MD)

## Educational Purpose

This project was developed as a means to learn and explore the capabilities of Blazor Fluent UI. While the primary objective was to access the Edaman API for recipe data, the focus was equally on leveraging various Fluent UI components and patterns.

### Learning Objectives

- Gain familiarity with Blazor Fluent UI components and their usage.
- Understand how to integrate external APIs into Blazor applications.
- Practice building responsive and user-friendly web interfaces.
- Explore data visualization and presentation techniques.

## Work in Progress

Please note that this project is currently a work in progress. While it provides basic functionality for recipe search and access to the Edaman API, it is expected to evolve over time.

### Future Enhancements

- **Additional Components:** The project may incorporate new components and features to enhance usability and functionality.
- **Improved User Experience:** Efforts will be made to enhance the user interface and overall user experience.
- **Bug Fixes and Optimization:** Any reported bugs will be addressed, and code optimization will be performed for better performance.

  ---
## Overview

Edaman API with Fluent UI is a web application that utilizes the Edaman API to provide recipe search functionality and access to a comprehensive food database. Built with Blazor Fluent UI, this application offers a user-friendly interface for searching, browsing, and saving favorite recipes.

## Features

- **Recipe Search:** Users can search for recipes based on keywords, ingredients, or dietary preferences.
- **Food Database:** Access to a vast database of ingredients, nutritional information, and recipes.
- **User-friendly Interface:** Intuitive design and navigation for a seamless user experience.
- **Responsive Design:** The application is optimized for various screen sizes and devices.
- **Fast responses:** Users can select recipes from prior searches, thus avoiding trips to the Edaman api, allowing offline searches for quick access.

## Screenshots

![RecipeSearch](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/e5f0c4f2-158f-4a08-81ed-c8c342fd2469)
![RecipeSearchResult](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/f1d5bc1a-1866-4413-9d0a-a763cdb9b80c)

**Recipe search**
***
![FoodDatabaseSearch](https://github.com/fauxtix/EdamanApiWithFluentUI/assets/49880538/de5d9040-4905-496e-930c-d8d990eb11fe)

**Food database search**
***
## Installation

To install the Edaman API with Fluent UI locally, follow these steps:

1. **Clone Repository:**
   git clone https://github.com/fauxtix/EdamanApiWithFluentUI

2. **Navigate to Directory:**
   cd EdamanApiWithFluentUI

3. **Install Dependencies:**
   dotnet restore

4. **Update appsettings.json**
   Include your Edaman APP_ID and API_KEY
   
5. **Run Application:**
   dotnet run

6. **Access Application:**
Open a web browser and go to `http://localhost:<port>`.

## Usage

1. **Search for Recipes:**
Enter keywords, ingredients, or dietary preferences into the search bar and press enter to see relevant recipes.

2. **View Recipe Details:**
Click on the 'Preparation' button in the card, and navigate to the 'source' site, to view detailed information including ingredients, instructions, and nutritional facts.

3. **Explore Food Database:**
Browse through the food database to discover new ingredients, recipes, and nutritional information.

## Technologies Used

- Blazor Fluent UI
- Edaman API
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
