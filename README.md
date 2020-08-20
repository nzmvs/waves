# waves
A .NET Core console app that interacts with [ReqRes API](https://reqres.in/). The app classifies and displays [colors](https://reqres.in/api/example?per_page=2&page=1) based on following rules:
* if pantone value is divisible by 3 (no residual), then append color to group 1
* if pantone value is divisible by 2 **and** not divisible by 3, then append color to group 2
* append all other cases to group 3

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
will fetch 4 results from page 3. Per default, *page = 1* and *perPage = 2*.
