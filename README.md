# dotnet-xunit-restease-microservice-automation

**Resources**
- [Xunit](https://github.com/xunit/xunit)
- [RestEase](https://github.com/canton7/RestEase)
- [Shouldly](https://github.com/shouldly/shouldly)


### Windows

**Requirements**

[PowerShell 3](https://www.microsoft.com/en-us/download/details.aspx?id=34595) must be enabled for User account

```
set-executionpolicy unrestricted -s cu
```

#### Install Scoop:
```
iex (new-object net.webclient).downloadstring('https://get.scoop.sh')
```

#### Install Git
```
scoop install git
```

#### Install .NET Core
```
$ scoop install dotnet
```

Then
```
$ dotnet --version
2.1.3
```

### Run Tests

Restore packages
```
$ dotnet restore
```

Test
```
$ dotnet xunit
```

Test a specific Microservice
```
$ dotnet xunit -namespace "Services.Tests.UsersTests"
```

Test a specific endpoint
```
$ dotnet xunit -class "Services.Tests.UsersTests.GetUser"
```