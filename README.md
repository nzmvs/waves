# waves
A simple .NET Core console app that interacts with [ReqRes API](https://reqres.in/).

## Dependencies
* .NET Core 3.1

## Usage
In console/PowerShell: 
```
dotnet run
```
Or just call the executable. Additionaly, you can pass *page* and *perPage* parameters, eg.:
```
dotnet run -- 3 4
```
Per default, *page = 1* and *perPage = 2*.
