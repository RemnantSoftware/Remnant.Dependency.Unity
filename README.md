# Remnant Dependency Unity
Unity dependency injection adapter


## Nuget package:

        Install-Package Remnant.Dependency.Unity -Version 1.1.0
 
Create container for Unity
```csharp
var unity = new UnityContainer();
var container = Container.Create("MyContainer", new UnityAdapter(unity));
```

Get direct access to the internal DI container
```csharp
var unity = Container.Instance.InternalContainer<UnityContainer>();
```
