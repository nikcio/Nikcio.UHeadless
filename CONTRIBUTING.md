# Welcome to contributing and thank you for considering contributing!

## Tools

* Visual Studio or Visual Studio Code
* Docker
* Node (Or familiarity with the docker cli)

## Setup the environment

To setup the environment for developing on UHeadless open the root of the project start Docker on you machine and run
```
pnpm setup
```

If you don't use Node you can use the command found in the [package.json](package.json)

## Open the project

Now you can go ahead and open the project. You can find a solution at src/Nikcio.UHeadless.sln and test/test.sln

The src solution contains all projects of the UHeadless packages. The test solution contains testing projects that be used to test the package. This test project uses uSync to allow for a quick setup.

## Start the test solution

You can go ahead and start the test project and running uSync from the Settings tab in Umbraco. This will create a document type that you can use for testing.

### GraphQL endpoint

You can access the GraphQL endpoint from `/graphql`

This endpoint uses token based authentication with the `Bearer` authentication key. To get a token use the following steps:

* CREATE APIKEY: https://localhost:44330/api/auth/createapikey?apikey=hello
* GET TOKEN: https://localhost:44330/api/auth/authenticate?apikey=hello

You can change the port if you're using IISExpress to launch the site.

This token is valid for about 6-7 years so it's only necessary to create one. This token can be used at the `/graphql` endpoint by clicking the settings icon in the top right and selecting Authorization and type `Bearer` then pasting the token.

## CI/CD

This project uses a few different messures to ensure the best possible code and maintainability.

### Code analysis

It's running the following code analysis engines. This will come up when opening a PR and it meant to be a help for anyone contributing. If there's any confilcts in the recommondations then this list is what should decide which should take presedence (Top down).

* SonarCloud
* Codacy
* Codeclimate

## IDE

To catch the most issues with the code we recommend to use [SonarLint](https://www.sonarlint.org/) in your IDE.