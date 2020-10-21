# WPF demo application

## Contents

0. [Purpose](#Purpose)
1. [Functional requirements](#Functional-requirements)
2. [The solution overview](#The-solution-overview)
    1. [Core](#Core)
    2. [UI](#UI)
    3. [Helpers](#Helpers)
    4. [Tests](#Tests)
3. [User interface](#User-interface)
    1. [The main window](#The-main-window)
    2. [Calculator](#Calculator)
    3. [Currency converter](#Currency-converter)
    4. [C# test](#C-test)
    
## Purpose
This software application  is the WPF .NET solution. The program's purpose is to demonstarte WPF possibilities and MVVM pattern. The solution consists of different .NET projects to apply styles, to create MVVM models and view models, the project to use unit tests and the project with WPF demonstrations.    
In turn main project demonstrates calculator and currency converter funcionalities.    
Some functionalities are based on the ideas of the project https://github.com/angelsix/fasetto-word

[:arrow_up:Contents](#Contents)
___
## Functional requirements

The .NET application has been created in the MS Viual Studio 2017 environment and uses .NET 4.6 Framework.    
Some projects (the Core project) from the solution use the plugin "FodyPropertyChanged", which raises the `PropertyChanged` event, into property setters of classes which implement `INotifyPropertyChanged`. The plugin can found here https://github.com/Fody/PropertyChanged. 

[:arrow_up:Contents](#Contents)
____
## The solution overview

The solution has the following .NET projects:

#### Core

This project contains all models and view models the presantion solution. Mainly all view models in te project derive from the `BaseModel` class. From it derives `BaseViewModel` class, which contains main methods to operate with windows (close, open, open dialog, activated). From this class derives `WindowViewModel` to manipulate with main window in the presentaion project.    
To show windows with panel and title is used `TitlePanelViewModel`. From it derive `CalculatorViewModel` and `CurrencyConverterViewModel`.    
Also, this project contains different attached properties and the class to create relay commands.
    
[:arrow_up:Contents](#Contents)
____

#### UI

This project conatins different resource dictionaries with styles. `Windows.xaml` conatains styles for windows’ styling,  `Buttons.xaml` contains buttons’ styles for the main window and other windows. `Colors.xaml` contains common colors and brushes to use in the whole solution.
    
[:arrow_up:Contents](#Contents)
____

#### Helpers

This purpose of this project is to create additional methods, classes and functions to use in another projects in the solution. There can be found different animations for windows, extension methods and behaviours.

#### Tests

This project contains unit tests for the View Models from the `Core` project.
    
[:arrow_up:Contents](#Contents)
____

## User interface

#### The main window

On the "MainWindow.xaml" form the user can make a choice between "calculator", "currency converter" and "C# Test".  

![Image alt](https://github.com/YuryYuhno/WPF_Presentation/blob/master/Images/Main.png)

[:arrow_up:Contents](#Contents)
____


#### Calculator

On the "Calculator.xaml" form is presented a calculator for simple mathematical computations. 

![Image alt](https://github.com/YuryYuhno/WPF_Presentation/blob/master/Images/Calculator.png)

[:arrow_up:Contents](#Contents)
____

#### Currency converter

On this form user can calculate prices of the currenties based on the rates from Internet.

![Image alt](https://github.com/YuryYuhno/WPF_Presentation/blob/master/Images/CurrencyConverter.png)

[:arrow_up:Contents](#Contents)
____

#### C# test

On the "CSharpTestWindow.xaml" form user can perform the simple C# test and review given answers.

![Image alt](https://github.com/YuryYuhno/WPF_Presentation/blob/master/Images/Test.png)

[:arrow_up:Contents](#Contents)
____

