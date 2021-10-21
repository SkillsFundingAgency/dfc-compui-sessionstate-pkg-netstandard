# Digital First Careers - Session State Management

## Introduction

This Nuget provides a Session State service for the storage/retrieval in Cosmos.

## Getting Started

This is a self-contained Visual Studio 2019 solution containing a number of projects (Session State service and a unit test project) that is used to build a Nuget for consumption by Composite UI child apps.

## Using this Nuget

To use this Nuget in a Composite UI child app, add DFC.Compui.Sessionstate from Nuget. Then apply the following to your Composite Child app's startup class, ConfigureServices method:

Simple Document Service use

To register the Session State Nuget, add either of the following to the child app Startup class ConfigureServices method:

```c#
services.AddSessionStateServices<SessionDataModel>(cosmosDbConnectionSessionState, env.IsDevelopment());
```

To use of the Session State Nuget, inject the following in class constructors:

```c#
ISessionStateService<SessionDataModel> sessionStateService
```

Sample use of the Session State in code:

```c#
...
var compositeSessionId = Request.CompositeSessionId();
if (compositeSessionId.HasValue)
{
    var sessionStateModel = await sessionStateService.GetAsync(compositeSessionId.Value).ConfigureAwait(false);
 
    sessionStateModel.State!.CurrentDatetime = DateTime.Now;
    sessionStateModel.State!.Visits++;
 
    var result = await sessionStateService.SaveAsync(sessionStateModel).ConfigureAwait(false);
}
...
```


## Built With

* Microsoft Visual Studio 2019
* .Net Standard 2.1
