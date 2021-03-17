# HieloCalculatorApp
A gui version of Hielo Calculator, with more drawbacks and less precision than the CLI one.

## Screenshots
![image](https://user-images.githubusercontent.com/64178604/111410606-70838b80-86af-11eb-9cab-5c2321603e45.png)
![image](https://user-images.githubusercontent.com/64178604/111410639-8002d480-86af-11eb-9cee-8088ec1bbb10.png)



## Technologies
Project is created with:
* [Avalonia Framework](https://avaloniaui.net/)
* [DecimalEX Nuget Package](https://www.nuget.org/packages/DecimalMath.DecimalEx/)
* [C# Dotnet 5.0103](https://dotnet.microsoft.com/)

## Drawbacks
* Missing Decimal Point
* Units are not precise, they are rounded.

## Setup
Install the [Dotnet 5.0103](https://dotnet.microsoft.com/) framework for C# and download the DecimalEX nuget package.
```
$ gitclone https://github.com/SugarBlank/HieloCalculator/
$ cd ../HieloCalculator
$ dotnet add package DecimalMath.DecimalEx --version 1.0.2
$ Add the Avalonia framework on https://avaloniaui.net/
$ dotnet run
```
## License
[MIT](https://choosealicense.com/licenses/mit/)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Suggestions for places to clean up code would be great too.

Please make sure to update tests as appropriate.
