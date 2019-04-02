# PortfolioBossTests

PortfolioBossTests is a test project that runs and validates UI scenarios on Windows 10. 

## Requirements

- Windows 10 PC with the latest Windows 10 version (Version 1809 or later)
- Microsoft Visual Studio 2017 or later


## Getting Started

1. Run `WinAppDriver.exe` on the test device
2. Open `PortfolioBossAutomatedTests.sln` in Visual Studio
3. Select **Build** > **Rebuild Solution**
4. Select **Test** > **Windows** > **Test Explorer**
5. Select **Run All** on the test pane or through menu **Test** > **Run** > **All Tests**

> Once the project is successfully built, you can use the **TestExplorer** to pick and choose the test scenario(s) to run

> If Visual Studio fail to discover and run the test scenarios:
> 1. Select **Tools** > **Options...** > **Test**
> 2. Under *Active Solution*, uncheck *For improved performance, only use test adapters in test assembly folder or as specified in runsettings file*

## Adding/Updating Test Scenario

Please follow the guidelines below to maintain test reliability and conciseness:
1. Maintain original state after test runs and keep clean state in between tests when possible
2. Make sure to review all the new tests

# portfoliobossautomation
