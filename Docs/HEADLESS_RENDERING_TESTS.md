# Headless Rendering Tests

This document explains how to run and maintain Playwright-based layout tests in the `HtmlForgeX.Tests` project.

## Installing browsers

Playwright requires browser binaries. Before running the integration tests, execute:

```bash
pwsh bin/Release/net8.0/playwright.ps1 install
```

If you run tests for a different target framework, replace `net8.0` accordingly.

## Updating baselines

The screenshot baseline files live under `HtmlForgeX.Tests/Baselines`. When a baseline image is missing, the tests will generate it automatically on the next run. When layout changes are intended, regenerate baselines by setting the environment variable `UPDATE_BASELINES=true` during test execution. The new screenshot will overwrite the existing baseline.

```bash
UPDATE_BASELINES=true dotnet test HtmlForgeX.Tests/HtmlForgeX.Tests.csproj -c Release --no-build
```

Review the updated images before committing them.
