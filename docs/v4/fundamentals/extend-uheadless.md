# Extending the Package with Add-On Packages

## Add-On Packages Overview

Nikcio.Uheadless supports extensibility through add-on packages, which provide additional functionality and features to enhance the capabilities of the core package. This documentation provides guidelines on how to extend the package with add-on packages. Currently, the following add-on packages available are:

| Add-On Package                            | Description                                              |
| ----------------------------------------- | -------------------------------------------------------- |
| Nikcio.UHeadless.Members                  | Adds the ability to query for members and their data     |

## Installing an Add-On Package

To install an add-on package, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to your project directory.
3. Run the following command:

```shell
dotnet add [PackageName]
```

Replace `[PackageName]` with the name of the add-on package you want to install. For example, to install the Nikcio.UHeadless.Members add-on package, use the following command:

```shell
dotnet add Nikcio.UHeadless.Members
```

This command will add the specified add-on package to your project and update the project file with the necessary references and dependencies.

## Adding Functionality with Add-On Packages

Once you have installed an add-on package, you can start leveraging the additional functionality it provides. Refer to the documentation of the specific add-on package for detailed instructions on how to use its features and integrate them into your project.

| Add-On Package                            | Documentation                                            |
| ----------------------------------------- | -------------------------------------------------------- |
| Nikcio.UHeadless.Members                  | [Querying members](getting-started/querying/members.md)  |