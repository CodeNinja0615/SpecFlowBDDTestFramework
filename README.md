# 🧪🔧 .NET Automation Framework with NUnit, SpecFlow & Azure Pipelines

![.NET](https://img.shields.io/badge/.NET-Core%207.0-purple?logo=dotnet&style=flat-square)
![C#](https://img.shields.io/badge/C%23-Supported-blue?logo=csharp&style=flat-square)
![SpecFlow](https://img.shields.io/badge/SpecFlow-BDD-orange?logo=spectator&style=flat-square)
![NUnit](https://img.shields.io/badge/NUnit-Testing-green?logo=nunit&style=flat-square)
![Azure DevOps](https://img.shields.io/badge/Azure-Pipelines-blue?logo=azure-devops&style=flat-square)

An automation test framework using **.NET Core**, **NUnit**, **SpecFlow** (for BDD), and integration-ready with **Azure DevOps Pipelines**. Built for scalable, maintainable, and readable test automation with support for **parallel execution** and rich **reporting**.

---

## 📦 Prerequisites

- [.NET SDK (>= 7.0)](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) with:
  - NUnit Test Adapter
  - SpecFlow Extension
- Azure DevOps account (for CI/CD integration)

🛠 Prerequisites (VS Code Setup)
✅ .NET SDK 7.0 or later
✅ Visual Studio Code
✅ VS Code Extensions:
    C# (by Microsoft)
    SpecFlow for VS Code (optional, for .feature syntax highlighting)
✅ NuGet CLI (optional, helps manage packages)

# ⚠️ Tip: Use the Test Explorer sidebar in VS Code (via the C# extension) to visually run/debug your tests.
---

## 🚀 Getting Started

### 1️⃣ Clone the repository
```bash
git clone https://github.com/your-org/your-dotnet-framework.git
cd your-dotnet-framework
```
### 2️⃣ Restore NuGet packages
```bash
dotnet restore
```

### 3️⃣ Run Tests
```bash 
dotnet test
```

# 🧰 Tech Stack
```
.NET Core -- Base Framework
C# -- Language
NUnit -- Test Runner
SpecFlow -- BDD with Gherkin
Azure Pipelines -- CI/CD
```

# 📁 Project Structure
```
├── Features/                   # .feature files
├── StepDefinitions/           # Step bindings
├── Hooks/                     # SpecFlow hooks (Before/After)
├── Drivers/                   # WebDriver init and config
├── Pages/                     # Page Objects
├── Utilities/                 # Helpers and utils
├── Reports/                   # Test reports
├── TestRunner.csproj          # Project file
└── README.md
```

# 📊 Reporting
**You can use:**
SpecFlow+ LivingDoc
ExtentReports (via custom integration)
NUnit XML reports (default for CI)

## Generate NUnit XML Reports
```bash
dotnet test --logger:"nunit;LogFilePath=TestResult.xml"
```

# 🧪 BDD with SpecFlow
 Leverage Gherkin syntax to write feature files that define your test cases in a readable and structured way.

 ## ✍️ Sample Feature File
 ```s
 Feature: EndToEndFlow
  As a user, I want to log in, add products to the cart, and complete the purchase successfully.

  @Inline
  Scenario: Verify End-to-End purchase flow with inline values
    Given I log in with username "rahulshettyacademy" and password "learning"
    When I add "iphone X" and "Blackberry" to the cart
    And I proceed to checkout
    Then I should see the selected products in the checkout page
    And I should see a success message upon purchase

  @Smoke
  Scenario Outline: Verify End-to-End purchase flow
    Given I log in with username "<username>" and password "<password>"
    When I add "<product1>" and "<product2>" to the cart
    And I proceed to checkout
    Then I should see the selected products in the checkout page
    And I should see a success message upon purchase

    Examples:
      | username           | password | product1 | product2   |
      | rahulshettyacademy | learning | iphone X | Blackberry |
      | rahulshettyacademy | learning | iphone X | Blackberry |

 ```

 ## 🔗 Corresponding Step Definitions (C# Example)
```C#
[Given(@"I log in with username ""(.*)"" and password ""(.*)""")]
public void GivenILogInWithUsernameAndPassword(string username, string password)
{
}

[When(@"I add ""(.*)"" and ""(.*)"" to the cart")]
public void WhenIAddProductsToTheCart(string product1, string product2)
{
}

[When(@"I proceed to checkout")]
public void WhenIProceedToCheckout()
{
}

[Then(@"I should see the selected products in the checkout page")]
public void ThenIShouldSeeTheSelectedProducts()
{
}

[Then(@"I should see a success message upon purchase")]
public void ThenIShouldSeeASuccessMessage()
{
}
```

## ▶️ Running Tagged Scenarios
```bash
dotnet test --filter "TestCategory=Smoke"
dotnet test --filter "TestCategory=Smoke|TestCategory=Inline"
```