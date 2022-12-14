![GitHub Workflow Status](https://img.shields.io/github/workflow/status/flaviobergamini/DocumentValidation/Build%20and%20deploy%20package)

# Class Library Document Validation

<h1 align="center">Document Validation</h1>

### :books: Description

<p>Class library for the Computer Engineering course TCC project.</p>
<p>This class library project was created to be used in the API and in the future on the website of this TCC project, both developed in .NET Core 6.0. This DocumentValidation class library can be used in any project, just look on nuget.org</p>

####
- This class library has the purpose of Boolean validation of Brazilian documents, being:

  -  Phone number;
  -  Zip code;
  -  Email;
  -  CNPJ;
  -  CPF.


### :hammer_and_wrench: Installation and Execution
#### Preparing the computer environment to run the programs
- [Git](https://git-scm.com/)
- [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Visual Studio](https://visualstudio.microsoft.com/pt-br/)
- [Visual Studio Code](https://github.com/Microsoft/vscode)

You can use the IDE or editor of your choice, but I recommend Visual Studio or Visual Studio Code

If you're using Visual Studio Code, go to [DocumentValidation nuget.org](https://www.nuget.org/packages/DocumentValidation/) to install dependencies for your project.

If you are using Visual Studio, go to "Tools -> Manage Nuget Packages -> Manage Nuget Packages for Solution..."

<img src="https://raw.githubusercontent.com/flaviobergamini/DocumentValidation/images/nuget.png">

```csharp
using DocumentValidation;

var cpf = "999.999.999-99";
bool validateCpf = cpf.ValidateCpf();

var email = "flavio@hotmail.com";
bool validateEmail = email.ValidateEmail();

var phone = "(19)99999-9999";
bool validatePhone = phone.ValidatePhone();

string cnpj = "99.999.999/9999-99";
bool validateCnpj = cnpj.ValidateCnpj();

string cep = "37540-000";
bool validateCep = cep.ValidateCep();
```

You can also clone the repository:
```
git clone https://github.com/flaviobergamini/DocumentValidation.git
```

#### Installing the dependencies
In the respective folder, install the .NET dependencies using the command:
```
dotnet restore
```

#### Building project
After the project dependencies installations are complete, build the project using the command:
```
dotnet build
```
Because it is a class library, the dotnet run command will not work.

### :hammer_and_wrench: Execution of Unit Tests
```
dotnet test
```
## :gear: Autor

* **Fl??vio Henrique Madureira Bergamini** - [Fl??vio](https://github.com/flaviobergamini)
