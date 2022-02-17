# Remnant Dependency Unity
Unity dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.Unity -Version 1.0.0
        
```csharp
var unity = new UnityContainer();
var container = Container.Create("MyContainer", new UnityAdapter(unity));
```
