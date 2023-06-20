# Cryptocurrencies Management App

This is a WPF (Windows Presentation Foundation) application that provides users with various information related to cryptocurrencies. 
The application utilizes the <a href="https://docs.coincap.io/">CoinCap API</a> to retrieve and display cryptocurrency data.

## Functionality
The application offers the following features:

1. Multi-page application with navigation.
2. Main Page: Displays the top N currencies by popularity on a selected market. The value of N can be customized by the user (default is 10).
3. Currency Details Page: Shows detailed information about a specific currency, including its price, volume, price change, and the markets where it can be purchased along with the corresponding prices. Users can navigate to this page from the home page.
4. Currency Search: Allows users to search for a currency by its name.
5. Currency Conversion Page: Enables users to convert one currency to another. This page also provides a list of supported currencies.

## Libraries Used
The project incorporates the following libraries:

1. MediatR: A library for implementing the Mediator pattern, which helps decouple the communication between different components of the application.
2. AutoMapper: A mapping library used for mapping between different object types.
3. Microsoft.DependencyInjection: A lightweight dependency injection container for managing object dependencies.

For the UI elements, the following libraries were utilized:

1. FontAwesome.WPF: A library that provides vector icons for use in WPF applications.
2. MahApps.Metro.IconPacks.Material: A library that includes Material Design icons for use in WPF applications.

## Project Structure
The project is structured into several layers:

1. Contracts: This project contains data transfer objects (DTOs) used for communication with the CoinCap API.
2. Application: This layer houses the application logic. It depends on the Contracts layer but has no dependencies on any other layer or project. The Application layer defines interfaces that are implemented by external layers.
3. Infrastructure: The Infrastructure layer contains classes responsible for accessing external resources, such as the CoinCap API.
4. UI: This layer represents the WPF application itself. It depends on both the Application and Infrastructure layers. The DesktopUi layer provides the user interface and facilitates interaction with the application.

## Getting Started

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file in Visual Studio.
3. Build the solution to restore dependencies.
4. Set the DesktopUi project as the startup project.

Run the application.

## Images

